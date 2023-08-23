using BusinessCape.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Newtonsoft.Json.Linq;
using DataCape.Models;
using PersistenceCape.Interfaces;
using PersistenceCape.EmailConfiguration;
using NuGet.Common;
using Microsoft.AspNetCore.Authorization;
using SenaOnPrinting.Permissions;

namespace SenaOnPrinting.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly string secret_key;

        private readonly AuthenticationService _service;

        //private readonly IAppPermissionService _appPermissionService;

        private readonly IEmailRepository _emailRepository;

        private bool result;

        public AuthenticationController(AuthenticationService service, IConfiguration configuration, IEmailRepository emailRepository)
        {
            _service = service;
            secret_key = configuration["Jwt:SecretKey"];
            _emailRepository = emailRepository;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] Dictionary<string, string> data_form)
        {            
            string email = data_form.GetValueOrDefault("email", "");
            string password = data_form.GetValueOrDefault("password", "");
            var user = await _service.Authenticate(email, password);            

            if (user != null)
            {
                //HashSet<String> appPermissions = await _appPermissionService.GetPermissionsAsync(user.Id);
                var secret = Encoding.ASCII.GetBytes(secret_key);
                var claims = new ClaimsIdentity();

                claims.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.Names));
                claims.AddClaim(new Claim(ClaimTypes.Email, email));
                claims.AddClaim(new Claim("role", user.RoleId.ToString()));
                //claims.AddClaim(new Claim("permissions", appPermissions.ToString()));


                var token_descriptor = new SecurityTokenDescriptor
                {
                    Subject = claims,
                    Expires = DateTime.Today.AddDays(8),
                    Audience = "http://localhost:7262/",
                    Issuer = "http://localhost:7262/",
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(secret), SecurityAlgorithms.HmacSha256Signature)
                };

                var token_handler = new JwtSecurityTokenHandler();
                var token_configuration = token_handler.CreateToken(token_descriptor);

                string _token = token_handler.WriteToken(token_configuration);

                return StatusCode(StatusCodes.Status200OK, new { message = "Inicio de Sesion Exitoso", token = _token});
            } else
            {
                return StatusCode(StatusCodes.Status401Unauthorized, new { message = "Credenciales incorrectas, intente de nuevo", token = "" });
            }
        }
        [HttpDelete]
        [Route("logout")]
        public IActionResult Logout(string token)
        {
            return null;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("forgot_password")]
        public async Task<IActionResult> ForgotPassword([FromBody] Dictionary<string, string> recovery_email)
        {            
            string email = recovery_email.GetValueOrDefault("email", "");
            var user = await _service.ForgotPassword(email);
            if (user != null && user.ForgotPasswordToken != null)
            {
                var token = user.ForgotPasswordToken;
                var subject = "SENAonPrinting - Recuperar contraseña";
                var forgotPasswordLink = $"http://localhost:5173/restaurar_contraseña?token={token}&email={email}";
                var message = new Message(new string[] { user.Email }, subject, $"<!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.0 Transitional//EN\" \"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd\"><html xmlns=\"http://www.w3.org/1999/xhtml\" xmlns:o=\"urn:schemas-microsoft-com:office:office\"><head><meta charset=\"UTF-8\"><meta content=\"width=device-width, initial-scale=1\" name=\"viewport\"><meta name=\"x-apple-disable-message-reformatting\"><meta http-equiv=\"X-UA-Compatible\" content=\"IE=edge\"><meta content=\"telephone=no\" name=\"format-detection\"><title>New message</title><!--[if (mso 16)]><style type=\"text/css\">     a {{text-decoration: none;}}     </style><![endif]--><!--[if gte mso 9]><style>sup {{ font-size: 100% !important; }}</style><![endif]--><!--[if !mso]><!-- --><link href=\"https://fonts.googleapis.com/css?family=Lato:400,400i,700,700i\" rel=\"stylesheet\"><!--<![endif]--><!--[if gte mso 9]><xml> <o:OfficeDocumentSettings> <o:AllowPNG></o:AllowPNG> <o:PixelsPerInch>96</o:PixelsPerInch> </o:OfficeDocumentSettings> </xml><![endif]--><style type=\"text/css\">.rollover:hover .rollover-first {{ max-height:0px!important; display:none!important; }} .rollover:hover .rollover-second {{ max-height:none!important; display:inline-block!important; }} .rollover div {{ font-size:0px; }} u ~ div img + div > div {{ display:none; }} #outlook a {{ padding:0; }} span.MsoHyperlink,span.MsoHyperlinkFollowed {{ color:inherit; mso-style-priority:99; }} a.es-button {{ mso-style-priority:100!important; text-decoration:none!important; }} a[x-apple-data-detectors] {{ color:inherit!important; text-decoration:none!important; font-size:inherit!important; font-family:inherit!important; font-weight:inherit!important; line-height:inherit!important; }} .es-desk-hidden {{ display:none; float:left; overflow:hidden; width:0; max-height:0; line-height:0; mso-hide:all; }} .es-header-body a:hover {{ color:#111111!important; }} .es-content-body a:hover {{ color:#7c72dc!important; }} .es-footer-body a:hover {{ color:#111111!important; }} .es-infoblock a:hover {{ color:#cccccc!important; }} .es-button-border:hover > a.es-button {{ color:#ffffff!important; }}@media only screen and (max-width:600px) {{*[class=\"gmail-fix\"] {{ display:none!important }} p, a {{ line-height:150%!important }} h1, h1 a {{ line-height:120%!important }} h2, h2 a {{ line-height:120%!important }} h3, h3 a {{ line-height:120%!important }} h4, h4 a {{ line-height:120%!important }} h5, h5 a {{ line-height:120%!important }} h6, h6 a {{ line-height:120%!important }} h1 {{ font-size:30px!important; text-align:center; line-height:120%!important }} h2 {{ font-size:26px!important; text-align:center; line-height:120%!important }} h3 {{ font-size:20px!important; text-align:center; line-height:120%!important }} h4 {{ font-size:24px!important; text-align:left }} h5 {{ font-size:20px!important; text-align:left }} h6 {{ font-size:16px!important; text-align:left }} .es-header-body h1 a, .es-content-body h1 a, .es-footer-body h1 a {{ font-size:30px!important }} .es-header-body h2 a, .es-content-body h2 a, .es-footer-body h2 a {{ font-size:26px!important }} .es-header-body h3 a, .es-content-body h3 a, .es-footer-body h3 a {{ font-size:20px!important }} .es-header-body h4 a, .es-content-body h4 a, .es-footer-body h4 a {{ font-size:24px!important }} .es-header-body h5 a, .es-content-body h5 a, .es-footer-body h5 a {{ font-size:20px!important }} .es-header-body h6 a, .es-content-body h6 a, .es-footer-body h6 a {{ font-size:16px!important }} .es-menu td a {{ font-size:16px!important }} .es-header-body p, .es-header-body a {{ font-size:16px!important }} .es-content-body p, .es-content-body a {{ font-size:14px!important }} .es-footer-body p, .es-footer-body a {{ font-size:16px!important }} .es-infoblock p, .es-infoblock a {{ font-size:12px!important }} .es-m-txt-c, .es-m-txt-c h1, .es-m-txt-c h2, .es-m-txt-c h3, .es-m-txt-c h4, .es-m-txt-c h5, .es-m-txt-c h6 {{ text-align:center!important }} .es-m-txt-r, .es-m-txt-r h1, .es-m-txt-r h2, .es-m-txt-r h3, .es-m-txt-r h4, .es-m-txt-r h5, .es-m-txt-r h6 {{ text-align:right!important }} .es-m-txt-j, .es-m-txt-j h1, .es-m-txt-j h2, .es-m-txt-j h3, .es-m-txt-j h4, .es-m-txt-j h5, .es-m-txt-j h6 {{ text-align:justify!important }} .es-m-txt-l, .es-m-txt-l h1, .es-m-txt-l h2, .es-m-txt-l h3, .es-m-txt-l h4, .es-m-txt-l h5, .es-m-txt-l h6 {{ text-align:left!important }} .es-m-txt-r img, .es-m-txt-c img, .es-m-txt-l img {{ display:inline!important }} .es-m-txt-r .rollover:hover .rollover-second, .es-m-txt-c .rollover:hover .rollover-second, .es-m-txt-l .rollover:hover .rollover-second {{ display:inline!important }} .es-m-txt-r .rollover div, .es-m-txt-c .rollover div, .es-m-txt-l .rollover div {{ line-height:0!important; font-size:0!important }} .es-spacer {{ display:inline-table }} a.es-button, button.es-button {{ font-size:20px!important }} a.es-button, button.es-button {{ display:inline-block!important }} .es-button-border {{ display:inline-block!important }} .es-m-fw, .es-m-fw.es-fw, .es-m-fw .es-button {{ display:block!important }} .es-m-il, .es-m-il .es-button, .es-social, .es-social td, .es-menu {{ display:inline-block!important }} .es-adaptive table, .es-left, .es-right {{ width:100%!important }} .es-content table, .es-header table, .es-footer table, .es-content, .es-footer, .es-header {{ width:100%!important; max-width:600px!important }} .adapt-img {{ width:100%!important; height:auto!important }} .es-mobile-hidden, .es-hidden {{ display:none!important }} .es-desk-hidden {{ width:auto!important; overflow:visible!important; float:none!important; max-height:inherit!important; line-height:inherit!important }} tr.es-desk-hidden {{ display:table-row!important }} table.es-desk-hidden {{ display:table!important }} td.es-desk-menu-hidden {{ display:table-cell!important }} .es-menu td {{ width:1%!important }} table.es-table-not-adapt, .esd-block-html table {{ width:auto!important }} .es-social td {{ padding-bottom:10px }} .h-auto {{ height:auto!important }} p, ul li, ol li, a {{ font-size:16px!important }} }}</style></head>\r\n<body style=\"width:100%;height:100%;padding:0;Margin:0\"><div class=\"es-wrapper-color\" style=\"background-color:#F4F4F4\"><!--[if gte mso 9]><v:background xmlns:v=\"urn:schemas-microsoft-com:vml\" fill=\"t\"> <v:fill type=\"tile\" color=\"#f4f4f4\"></v:fill> </v:background><![endif]--><table class=\"es-wrapper\" width=\"100%\" cellspacing=\"0\" cellpadding=\"0\" style=\"mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px;padding:0;Margin:0;width:100%;height:100%;background-repeat:repeat;background-position:center top;background-color:#F4F4F4\"><tr class=\"gmail-fix\" height=\"0\"><td style=\"padding:0;Margin:0\"><table cellspacing=\"0\" cellpadding=\"0\" border=\"0\" align=\"center\" style=\"mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px;width:600px\"><tr><td cellpadding=\"0\" cellspacing=\"0\" border=\"0\" style=\"padding:0;Margin:0;line-height:1px;min-width:600px\" height=\"0\"><img src=\"https://swvecs.stripocdn.email/content/guids/CABINET_837dc1d79e3a5eca5eb1609bfe9fd374/images/41521605538834349.png\" style=\"display:block;font-size:14px;border:0;outline:none;text-decoration:none;max-height:0px;min-height:0px;min-width:600px;width:600px\" alt=\"\" width=\"600\" height=\"1\"></td>\r\n</tr></table></td>\r\n</tr><tr><td valign=\"top\" style=\"padding:0;Margin:0\"><table cellpadding=\"0\" cellspacing=\"0\" class=\"es-content\" align=\"center\" style=\"mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px;width:100%;table-layout:fixed !important\"><tr><td align=\"center\" style=\"padding:0;Margin:0\"><table class=\"es-content-body\" style=\"mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px;background-color:transparent;width:600px\" cellspacing=\"0\" cellpadding=\"0\" align=\"center\"><tr><td align=\"left\" style=\"Margin:0;padding-top:15px;padding-right:10px;padding-bottom:15px;padding-left:10px\"><!--[if mso]><table style=\"width:580px\" cellpadding=\"0\" cellspacing=\"0\"><tr><td style=\"width:282px\" valign=\"top\"><![endif]--><table class=\"es-left\" cellspacing=\"0\" cellpadding=\"0\" align=\"left\" style=\"mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px;float:left\"><tr><td align=\"left\" style=\"padding:0;Margin:0;width:282px\"><table width=\"100%\" cellspacing=\"0\" cellpadding=\"0\" role=\"presentation\" style=\"mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px\"><tr><td class=\"es-infoblock es-m-txt-c\" align=\"left\" style=\"padding:0;Margin:0\"><p style=\"Margin:0;mso-line-height-rule:exactly;font-family:arial, 'helvetica\\ neue', helvetica, sans-serif;line-height:27px;letter-spacing:0;color:#CCCCCC;font-size:18px\">Put your preheader text here<br></p>\r\n</td></tr></table></td></tr></table><!--[if mso]></td><td style=\"width:20px\"></td>\r\n<td style=\"width:278px\" valign=\"top\"><![endif]--><table class=\"es-right\" cellspacing=\"0\" cellpadding=\"0\" align=\"right\" style=\"mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px;float:right\"><tr><td align=\"left\" style=\"padding:0;Margin:0;width:278px\"><table width=\"100%\" cellspacing=\"0\" cellpadding=\"0\" role=\"presentation\" style=\"mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px\"><tr><td align=\"right\" class=\"es-infoblock es-m-txt-c\" style=\"padding:0;Margin:0\"><p style=\"Margin:0;mso-line-height-rule:exactly;font-family:lato, 'helvetica neue', helvetica, arial, sans-serif;line-height:27px;letter-spacing:0;color:#CCCCCC;font-size:18px\"><a href=\"https://viewstripo.email\" class=\"view\" target=\"_blank\" style=\"mso-line-height-rule:exactly;text-decoration:underline;font-family:arial, 'helvetica neue', helvetica, sans-serif;font-size:12px;color:#CCCCCC\">View in browser</a></p>\r\n</td></tr></table></td></tr></table><!--[if mso]></td></tr></table><![endif]--></td></tr></table></td>\r\n</tr></table><table class=\"es-header\" cellspacing=\"0\" cellpadding=\"0\" align=\"center\" style=\"mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px;width:100%;table-layout:fixed !important;background-color:#7C72DC;background-repeat:repeat;background-position:center top\"><tr><td style=\"padding:0;Margin:0;background-color:#00324d\" bgcolor=\"#00324d\" align=\"center\"><table class=\"es-header-body\" cellspacing=\"0\" cellpadding=\"0\" align=\"center\" style=\"mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px;background-color:#7C72DC;width:600px\"><tr><td align=\"left\" bgcolor=\"#00324d\" style=\"Margin:0;padding-right:10px;padding-left:10px;padding-top:20px;padding-bottom:10px;background-color:#00324d\"><table width=\"100%\" cellspacing=\"0\" cellpadding=\"0\" style=\"mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px\"><tr><td valign=\"top\" align=\"center\" style=\"padding:0;Margin:0;width:580px\"><table width=\"100%\" cellspacing=\"0\" cellpadding=\"0\" role=\"presentation\" style=\"mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px\"><tr><td align=\"center\" style=\"Margin:0;padding-right:10px;padding-left:10px;padding-top:25px;padding-bottom:25px;font-size:0\"><img src=\"https://swvecs.stripocdn.email/content/guids/CABINET_a3e3f739f12a2493d723a80757793c6201b8874d01d0260df70b3d921f4fbf3a/images/image_20230821_212145264.png\" alt=\"\" style=\"display:block;font-size:14px;border:0;outline:none;text-decoration:none\" width=\"90\"></td>\r\n</tr></table></td></tr></table></td></tr></table></td>\r\n</tr></table><table class=\"es-content\" cellspacing=\"0\" cellpadding=\"0\" align=\"center\" style=\"mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px;width:100%;table-layout:fixed !important\"><tr><td style=\"padding:0;Margin:0;background-color:#00324D\" bgcolor=\"#00324D\" align=\"center\"><table class=\"es-content-body\" style=\"mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px;background-color:transparent;width:600px\" cellspacing=\"0\" cellpadding=\"0\" align=\"center\"><tr><td align=\"left\" style=\"padding:0;Margin:0\"><table width=\"100%\" cellspacing=\"0\" cellpadding=\"0\" style=\"mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px\"><tr><td valign=\"top\" align=\"center\" style=\"padding:0;Margin:0;width:600px\"><table width=\"100%\" cellspacing=\"0\" cellpadding=\"0\" style=\"mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:separate;border-spacing:0px;border-radius:4px;background-color:#FFFFFF\" bgcolor=\"#FFFFFF\" role=\"presentation\"><tr><td align=\"center\" style=\"Margin:0;padding-top:35px;padding-right:30px;padding-bottom:5px;padding-left:30px\"><h1 style=\"Margin:0;font-family:lato, 'helvetica neue', helvetica, arial, sans-serif;mso-line-height-rule:exactly;letter-spacing:0;font-size:48px;font-style:normal;font-weight:normal;line-height:58px;color:#111111\">¿Problemas para iniciar sesión?</h1>\r\n</td></tr><tr><td bgcolor=\"#ffffff\" align=\"center\" style=\"Margin:0;padding-bottom:5px;padding-top:5px;padding-right:20px;padding-left:20px;font-size:0\"><table width=\"100%\" height=\"100%\" cellspacing=\"0\" cellpadding=\"0\" border=\"0\" role=\"presentation\" style=\"mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px\"><tr><td style=\"padding:0;Margin:0;border-bottom:1px solid #FFFFFF;background:#FFFFFF none repeat scroll 0% 0%;height:1px;width:100%;margin:0px\"></td></tr></table></td></tr></table></td></tr></table></td></tr></table></td>\r\n</tr></table><table class=\"es-content\" cellspacing=\"0\" cellpadding=\"0\" align=\"center\" style=\"mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px;width:100%;table-layout:fixed !important\"><tr><td align=\"center\" style=\"padding:0;Margin:0\"><table class=\"es-content-body\" style=\"mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px;background-color:#FFFFFF;width:600px\" cellspacing=\"0\" cellpadding=\"0\" bgcolor=\"#ffffff\" align=\"center\"><tr><td align=\"left\" style=\"padding:0;Margin:0\"><table width=\"100%\" cellspacing=\"0\" cellpadding=\"0\" style=\"mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px\"><tr><td valign=\"top\" align=\"center\" style=\"padding:0;Margin:0;width:600px\"><table width=\"100%\" cellspacing=\"0\" cellpadding=\"0\" style=\"mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px;background-color:#FFFFFF\" bgcolor=\"#FFFFFF\" role=\"presentation\"><tr><td class=\"es-m-txt-l\" bgcolor=\"#ffffff\" align=\"left\" style=\"Margin:0;padding-bottom:15px;padding-top:20px;padding-right:30px;padding-left:30px\"><p style=\"Margin:0;mso-line-height-rule:exactly;font-family:lato, 'helvetica neue', helvetica, arial, sans-serif;line-height:27px;letter-spacing:0;color:#666666;font-size:18px\">Para restaurar su&nbsp;&nbsp;contraseña, por favor acceda a través del siguiente boton:</p>\r\n</td></tr></table></td></tr></table></td>\r\n</tr><tr><td align=\"left\" style=\"padding:0;Margin:0;padding-right:30px;padding-left:30px;padding-bottom:20px\"><table width=\"100%\" cellspacing=\"0\" cellpadding=\"0\" style=\"mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px\"><tr><td valign=\"top\" align=\"center\" style=\"padding:0;Margin:0;width:540px\"><table width=\"100%\" cellspacing=\"0\" cellpadding=\"0\" role=\"presentation\" style=\"mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px\"><tr><td align=\"center\" style=\"Margin:0;padding-right:10px;padding-left:10px;padding-top:40px;padding-bottom:40px\"><span class=\"es-button-border\" style=\"border-style:solid;border-color:#7C72DC;background:#00324d;border-width:1px;display:inline-block;border-radius:2px;width:auto\"><a class=\"es-button\" target=\"_blank\" style=\"mso-style-priority:100 !important;text-decoration:none !important;mso-line-height-rule:exactly;font-family:helvetica, 'helvetica neue', arial, verdana, sans-serif;font-size:20px;color:#FFFFFF;padding:10px 20px 10px 20px;display:inline-block;background:#00324d;border-radius:2px;font-weight:normal;font-style:normal;line-height:24px !important;width:auto;text-align:center;letter-spacing:0;mso-padding-alt:0;mso-border-alt:10px solid #00324d\" href=\"{forgotPasswordLink}\">Restaurar Contraseña</a></span></td>\r\n</tr></table></td></tr></table></td></tr></table></td>\r\n</tr></table><table class=\"es-content\" cellspacing=\"0\" cellpadding=\"0\" align=\"center\" style=\"mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px;width:100%;table-layout:fixed !important\"><tr><td align=\"center\" style=\"padding:0;Margin:0\"><table class=\"es-content-body\" style=\"mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px;background-color:transparent;width:600px\" cellspacing=\"0\" cellpadding=\"0\" align=\"center\"><tr><td align=\"left\" style=\"padding:0;Margin:0\"><table width=\"100%\" cellspacing=\"0\" cellpadding=\"0\" style=\"mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px\"><tr><td valign=\"top\" align=\"center\" style=\"padding:0;Margin:0;width:600px\"><table width=\"100%\" cellspacing=\"0\" cellpadding=\"0\" style=\"mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px\"><tr><td align=\"center\" style=\"padding:0;Margin:0;display:none\"></td>\r\n</tr></table></td></tr></table></td></tr></table></td></tr></table><table cellpadding=\"0\" cellspacing=\"0\" class=\"es-footer\" align=\"center\" style=\"mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px;width:100%;table-layout:fixed !important;background-color:transparent;background-repeat:repeat;background-position:center top\"><tr><td align=\"center\" style=\"padding:0;Margin:0\"><table class=\"es-footer-body\" cellspacing=\"0\" cellpadding=\"0\" align=\"center\" style=\"mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px;background-color:transparent;width:600px\"></table></td>\r\n</tr></table><table class=\"es-content\" cellspacing=\"0\" cellpadding=\"0\" align=\"center\" style=\"mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px;width:100%;table-layout:fixed !important\"><tr><td align=\"center\" style=\"padding:0;Margin:0\"><table class=\"es-content-body\" style=\"mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px;background-color:transparent;width:600px\" cellspacing=\"0\" cellpadding=\"0\" align=\"center\"><tr><td align=\"left\" style=\"Margin:0;padding-right:20px;padding-left:20px;padding-top:30px;padding-bottom:30px\"><table width=\"100%\" cellspacing=\"0\" cellpadding=\"0\" style=\"mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px\"><tr><td valign=\"top\" align=\"center\" style=\"padding:0;Margin:0;width:560px\"><table width=\"100%\" cellspacing=\"0\" cellpadding=\"0\" style=\"mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px\"><tr><td align=\"center\" style=\"padding:0;Margin:0;display:none\"></td>\r\n</tr></table></td></tr></table></td></tr></table></td></tr></table></td></tr></table></div></body></html>\r\n");

                _emailRepository.SendEmail(message);
                return StatusCode(StatusCodes.Status200OK, new { message = "Correo de restauracion de contraseña ha sido exitosamente enviado, por favor revise su bandeja de entrada" });
            }
            else
            {
                return StatusCode(StatusCodes.Status422UnprocessableEntity, new { message = "La direccion de correo proporcionada no se encuentra en el sistema." });
            }
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("recovery_password")]
        public async Task<IActionResult> RecoveryPassword([FromBody] Dictionary<string, string> recovery_data)
        {
            string email = recovery_data.GetValueOrDefault("email", "");
            string token = recovery_data.GetValueOrDefault("token", "");
            string password = recovery_data.GetValueOrDefault("password", "");
            string confirmPassword = recovery_data.GetValueOrDefault("confirmPassword", "");
            var result = await _service.RecoveryPassword(email, token, password, confirmPassword);
            if (result)
            {                
                return StatusCode(StatusCodes.Status200OK, new { message = "Contraseña restaurada con exito" });                
            }
            else
            {
                return StatusCode(StatusCodes.Status422UnprocessableEntity, new { messaqe = "Ocurrio un problema con la restauracion de la contraseña" });
            }
        }
    }
}
