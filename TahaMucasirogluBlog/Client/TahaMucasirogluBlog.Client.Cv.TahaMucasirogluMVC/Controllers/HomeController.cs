using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;
using TahaMucasirogluBlog.Client.Cv.TahaMucasirogluMVC.Managers.UrlManager;
using TahaMucasirogluBlog.Domain.Models.Concrete.Cv;
using TahaMucasirogluBlog.Domain.Return.Base;
using TahaMucasirogluBlog.Domain.Return.Concrete;

namespace TahaMucasirogluBlog.Client.Cv.TahaMucasirogluMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> logger;
        private readonly IUrlManager urlManager;
        private readonly HttpClient httpClient;
        public HomeController(ILogger<HomeController> logger, IUrlManager urlManager, HttpClient httpClient)
        {
            this.logger = logger;
            this.urlManager = urlManager;
            this.httpClient = httpClient;
        }

        public async Task<IActionResult> Index()
        {
            string requestUri = urlManager.Build("Cv", "GetTest");
            using HttpResponseMessage response = await httpClient.GetAsync(requestUri);
            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                logger.LogWarning("GET isteði yetkisiz: {RequestUri}", requestUri);
                throw new UnauthorizedAccessException("API returned 401 Unauthorized");
            }
            string json = await response.Content.ReadAsStringAsync();
            Return<CvResponseModel>? result = JsonConvert.DeserializeObject<Return<CvResponseModel>>(json);
            if (result == null)
            {
                logger.LogError("GET isteði sonucu deserialize edilemedi: {RequestUri}", requestUri);
                return Ok(new ErrorReturn(message: "Gelen veri parçalanamadý."));
            }
            return View(result);
        }


        /*
        public IActionResult Index()
        {
            GetExperienceTypeModel staj = new GetExperienceTypeModel()
            {
                Id = Guid.NewGuid(),
                Name = "Staj"
            };

            GetExperienceTypeModel gonullu = new GetExperienceTypeModel()
            {
                Id = Guid.NewGuid(),
                Name = "Gönüllü"
            };
            GetExperienceTypeModel calisma = new GetExperienceTypeModel()
            {
                Id = Guid.NewGuid(),
                Name = "Ýþ"
            };
            GetExperienceTypeModel proje = new GetExperienceTypeModel()
            {
                Id = Guid.NewGuid(),
                Name = "Proje"
            };
            GetExperienceTypeModel egitim = new GetExperienceTypeModel()
            {
                Id = Guid.NewGuid(),
                Name = "Eðitim"
            };

            CvResponseModel cvResponseModel = new CvResponseModel()
            {
                Info = new GetInfoModel()
                {
                    Id = Guid.NewGuid(),
                    Email = "tahamucasiroglu@gmail.com",
                    FullName = "Ahmet Taha Mücasiroðlu",
                    Location = "Ýstanbul - Ýzmir - Muðla/Fethiye - Ankara",
                    Phone = "553 735 62 89",
                },

                SocialLinks = new List<GetSocialLinkModel>()
                {
                    new GetSocialLinkModel()
                    {
                        Id = Guid.NewGuid(),
                        Name = "LinkedIn",
                        DisplayOrder = 1,
                        IconClass = "fa-brands fa-linkedin",
                        IsVisible = true,
                        Url = "https://www.linkedin.com/in/tahamucasiroglu/"
                    },
                    new GetSocialLinkModel()
                    {
                        Id = Guid.NewGuid(),
                        Name = "Github",
                        DisplayOrder = 2,
                        IconClass = "fa-brands fa-github",
                        IsVisible = true,
                        Url = "https://github.com/tahamucasiroglu"
                    },
                    new GetSocialLinkModel()
                    {
                        Id = Guid.NewGuid(),
                        Name = "Mail",
                        DisplayOrder = 3,
                        IconClass = "fa-solid fa-envelope",
                        IsVisible = true,
                        Url = "mailto:tahamucasiroglu@gmail.com"
                    },
                    new GetSocialLinkModel()
                    {
                        Id = Guid.NewGuid(),
                        Name = "Telefon",
                        DisplayOrder = 4,
                        IconClass = "fa-solid fa-phone",
                        IsVisible = true,
                        Url = "tel:+905537356289"
                    }
                },

                Skills = new List<GetSkillWithSubSkillsModel>()
                {
                    new GetSkillWithSubSkillsModel()
                    {
                        Id = Guid.NewGuid(),
                        Name = "Backend",
                        SubSkills = new List<GetSubSkillModel>()
                        {
                            new GetSubSkillModel()
                            {
                                Id = Guid.NewGuid(),
                                Name = ".Net Api Core",
                            },
                            new GetSubSkillModel()
                            {
                                Id = Guid.NewGuid(),
                                Name = "Ef Core",
                            },
                            new GetSubSkillModel()
                            {
                                Id = Guid.NewGuid(),
                                Name = "PostgreSQL",
                            },
                            new GetSubSkillModel()
                            {
                                Id = Guid.NewGuid(),
                                Name =  "Sql Server / Sql Express",
                            },
                            new GetSubSkillModel()
                            {
                                Id = Guid.NewGuid(),
                                Name = "Dapper",
                            }
                        }
                    },
                    new GetSkillWithSubSkillsModel()
                    {
                        Id = Guid.NewGuid(),
                        Name = "Mobile",
                        SubSkills = new List<GetSubSkillModel>()
                        {
                            new GetSubSkillModel()
                            {
                                Id = Guid.NewGuid(),
                                Name = "Flutter",
                            },
                            new GetSubSkillModel()
                            {
                                Id = Guid.NewGuid(),
                                Name = "Dart",
                            },
                            new GetSubSkillModel()
                            {
                                Id = Guid.NewGuid(),
                                Name = "Rest API",
                            }
                        }
                    },
                    new GetSkillWithSubSkillsModel()
                    {
                        Id = Guid.NewGuid(),
                        Name = "Frontend",
                        SubSkills = new List<GetSubSkillModel>()
                        {
                            new GetSubSkillModel()
                            {
                                Id = Guid.NewGuid(),
                                Name = ".NET MVC",
                            },
                            new GetSubSkillModel()
                            {
                                Id = Guid.NewGuid(),
                                Name = "Javascript",
                            },
                            new GetSubSkillModel()
                            {
                                Id = Guid.NewGuid(),
                                Name = "JQuery",
                            },
                            new GetSubSkillModel()
                            {
                                Id = Guid.NewGuid(),
                                Name =  "React",
                            },
                            new GetSubSkillModel()
                            {
                                Id = Guid.NewGuid(),
                                Name = "Bootstrap",
                            }
                        }
                    },
                    new GetSkillWithSubSkillsModel()
                    {
                        Id = Guid.NewGuid(),
                        Name = "Other",
                        SubSkills = new List<GetSubSkillModel>()
                        {
                            new GetSubSkillModel()
                            {
                                Id = Guid.NewGuid(),
                                Name = "Python",
                            },
                            new GetSubSkillModel()
                            {
                                Id = Guid.NewGuid(),
                                Name = "Script",
                            },
                            new GetSubSkillModel()
                            {
                                Id = Guid.NewGuid(),
                                Name = "Web Scraping",
                            },
                            new GetSubSkillModel()
                            {
                                Id = Guid.NewGuid(),
                                Name =  "Tensorflow",
                            },
                            new GetSubSkillModel()
                            {
                                Id = Guid.NewGuid(),
                                Name = "Clean Arch",
                            },
                            new GetSubSkillModel()
                            {
                                Id = Guid.NewGuid(),
                                Name =  "CQRS",
                            },
                            new GetSubSkillModel()
                            {
                                Id = Guid.NewGuid(),
                                Name = "Git",
                            }
                        }
                    }
                },
                Experiences = new List<GetExperienceWithTechnologyAndTypeModel>()
                {
                    new GetExperienceWithTechnologyAndTypeModel()
                    {
                        Id = Guid.NewGuid(),
                        StartDate = DateTime.Parse("01-07-2019"),
                        EndDate = DateTime.Parse("01-08-2019"),
                        ExperienceType = staj,
                        Provider = "",
                        Title = "Seydikemer Belediyesi Bilgi Ýþlem",
                        Reference = "",
                        Description = "Kamu kurumunda teknik destek saðladým. Program kurulumu, kullanýcý desteði,arýza tespiti ve çözüm süreçlerinde doðrudan sahada görev aldým.",
                        SubSkills = new List<GetSubSkillModel>()
                        {
                            new GetSubSkillModel()
                            {
                                Id= Guid.NewGuid(),
                                Name = "Teknik Destek"
                            },
                            new GetSubSkillModel()
                            {
                                Id= Guid.NewGuid(),
                                Name = "Kullanýcý Memnuniyeti"
                            },
                            new GetSubSkillModel()
                            {
                                Id= Guid.NewGuid(),
                                Name = "Problem Çözme"
                            },
                        }
                    },
                    new GetExperienceWithTechnologyAndTypeModel()
                    {
                        Id = Guid.NewGuid(),
                        StartDate = DateTime.Parse("01-11-2020"),
                        EndDate = DateTime.Parse("01-11-2020"),
                        ExperienceType = proje,
                        Provider = "",
                        Title = "Ayþe Tatile Çýksýn - Þifreli Mesajlaþma",
                        Reference = "",
                        Description = "RSA þifreleme ile arada sunucu olmadan, doðrudan P2P iletiþim yapan þifreli mesaþlaþma uygulamasý.",
                        SubSkills = new List<GetSubSkillModel>()
                        {
                            new GetSubSkillModel()
                            {
                                Id= Guid.NewGuid(),
                                Name = "Cryptology"
                            },
                            new GetSubSkillModel()
                            {
                                Id= Guid.NewGuid(),
                                Name = "Python"
                            },
                            new GetSubSkillModel()
                            {
                                Id= Guid.NewGuid(),
                                Name = "Socket"
                            },
                            new GetSubSkillModel()
                            {
                                Id= Guid.NewGuid(),
                                Name = "Thread"
                            },
                            new GetSubSkillModel()
                            {
                                Id= Guid.NewGuid(),
                                Name = "Tkinter"
                            },
                            new GetSubSkillModel()
                            {
                                Id= Guid.NewGuid(),
                                Name = "RSA"
                            },
                        }
                    },
                    new GetExperienceWithTechnologyAndTypeModel()
                    {
                        Id = Guid.NewGuid(),
                        StartDate = DateTime.Parse("01-06-2021"),
                        EndDate = DateTime.Parse("01-12-2021"),
                        ExperienceType = staj,
                        Provider = "",
                        Title = "NTN Yazýlým - Mobil Uygulama Geliþtirici",
                        Reference = "",
                        Description = "Atýk toplama tesisi için geliþtirilen, mobil ve tablet cihazlarda kullanýlacak Flutter tabanlý uygulamanýn geliþtirilmesinde görev aldým.",
                        SubSkills = new List<GetSubSkillModel>()
                        {
                            new GetSubSkillModel()
                            {
                                Id= Guid.NewGuid(),
                                Name = "Flutter"
                            },
                            new GetSubSkillModel()
                            {
                                Id= Guid.NewGuid(),
                                Name = "Dart"
                            },
                            new GetSubSkillModel()
                            {
                                Id= Guid.NewGuid(),
                                Name = "RESTful API"
                            },
                            new GetSubSkillModel()
                            {
                                Id= Guid.NewGuid(),
                                Name = "Layered Architecture"
                            },
                        }
                    },
                    new GetExperienceWithTechnologyAndTypeModel()
                    {
                        Id = Guid.NewGuid(),
                        StartDate = DateTime.Parse("01-09-2021"),
                        EndDate = DateTime.Parse("01-06-2022"),
                        ExperienceType = proje,
                        Provider = "",
                        Title = "TTB10 - Deepfake Video Tespiti",
                        Reference = "",
                        Description = "Tez projemiz için ürettiðimiz deepfake video tespiti. Hedef verisetinde %82'lik baþarý oraný ile tamamlandý.",
                        SubSkills = new List<GetSubSkillModel>()
                        {
                            new GetSubSkillModel()
                            {
                                Id= Guid.NewGuid(),
                                Name = "Python"
                            },
                            new GetSubSkillModel()
                            {
                                Id= Guid.NewGuid(),
                                Name = "Tensorflow"
                            },
                            new GetSubSkillModel()
                            {
                                Id= Guid.NewGuid(),
                                Name = "Cuda"
                            },
                            new GetSubSkillModel()
                            {
                                Id= Guid.NewGuid(),
                                Name = "OpenCV"
                            },
                            new GetSubSkillModel()
                            {
                                Id= Guid.NewGuid(),
                                Name = "CNN(Convolutional Neural Networks)"
                            },
                            new GetSubSkillModel()
                            {
                                Id= Guid.NewGuid(),
                                Name = "Pandas"
                            },
                        }
                    },
                    new GetExperienceWithTechnologyAndTypeModel()
                    {
                        Id = Guid.NewGuid(),
                        StartDate = DateTime.Parse("01-12-2022"),
                        EndDate = DateTime.Parse("01-04-2023"),
                        ExperienceType = gonullu,
                        Provider = "",
                        Title = "Bitranium Blockchain",
                        Reference = "",
                        Description = "Bitranium kripto para uygulamasýnda kýsa süreli gönüllü çalýþma saðladým. Proje sonradan kapandý.",
                        SubSkills = new List<GetSubSkillModel>()
                        {
                            new GetSubSkillModel()
                            {
                                Id= Guid.NewGuid(),
                                Name = "WEB3"
                            },
                            new GetSubSkillModel()
                            {
                                Id= Guid.NewGuid(),
                                Name = "Blockchain"
                            },
                            new GetSubSkillModel()
                            {
                                Id= Guid.NewGuid(),
                                Name = "React"
                            },
                            new GetSubSkillModel()
                            {
                                Id= Guid.NewGuid(),
                                Name = "Solidity"
                            },
                            new GetSubSkillModel()
                            {
                                Id= Guid.NewGuid(),
                                Name = "Contracts"
                            }
                        }
                    },
                    new GetExperienceWithTechnologyAndTypeModel()
                    {
                        Id = Guid.NewGuid(),
                        StartDate = DateTime.Parse("01-02-2023"),
                        EndDate = DateTime.Parse("01-07-2023"),
                        ExperienceType = egitim,
                        Provider = "",
                        Title = "Turkcell Bootcamp",
                        Reference = "",
                        Description = "Turkcell GYGY 2023 C# .NET Bootcamp eðitimi. Baþarýyla tamamlandý.",
                        SubSkills = new List<GetSubSkillModel>()
                        {
                            new GetSubSkillModel()
                            {
                                Id= Guid.NewGuid(),
                                Name = "C#"
                            },
                            new GetSubSkillModel()
                            {
                                Id= Guid.NewGuid(),
                                Name = ".NET API"
                            },
                            new GetSubSkillModel()
                            {
                                Id= Guid.NewGuid(),
                                Name = "Architecture"
                            },
                            new GetSubSkillModel()
                            {
                                Id= Guid.NewGuid(),
                                Name = "Algorithm"
                            }
                        }
                    },
                    new GetExperienceWithTechnologyAndTypeModel()
                    {
                        Id = Guid.NewGuid(),
                        StartDate = DateTime.Parse("01-07-2023"),
                        EndDate = DateTime.Parse("01-08-2023"),
                        ExperienceType = staj,
                        Provider = "",
                        Title = "Atmosware Backend Developer",
                        Reference = "",
                        Description = "Turkcell Bootcamp sonrasý Atmosware þirketinde 1 ay süren staj programý.",
                        SubSkills = new List<GetSubSkillModel>()
                        {
                            new GetSubSkillModel()
                            {
                                Id= Guid.NewGuid(),
                                Name = "C#"
                            },
                            new GetSubSkillModel()
                            {
                                Id= Guid.NewGuid(),
                                Name = ".NET API"
                            },
                            new GetSubSkillModel()
                            {
                                Id= Guid.NewGuid(),
                                Name = ".NET MVC"
                            },
                            new GetSubSkillModel()
                            {
                                Id= Guid.NewGuid(),
                                Name = "React"
                            },
                            new GetSubSkillModel()
                            {
                                Id= Guid.NewGuid(),
                                Name = "PostgreSQL"
                            },
                            new GetSubSkillModel()
                            {
                                Id= Guid.NewGuid(),
                                Name = "SOLID"
                            },
                            new GetSubSkillModel()
                            {
                                Id= Guid.NewGuid(),
                                Name = "DI"
                            }
                        }
                    },
                    new GetExperienceWithTechnologyAndTypeModel()
                    {
                        Id = Guid.NewGuid(),
                        StartDate = DateTime.Parse("01-04-2024"),
                        EndDate = DateTime.Parse("01-08-2024"),
                        ExperienceType = egitim,
                        Provider = "",
                        Title = "HWA .NET Bootcamp",
                        Reference = "",
                        Description = "HWA (Veli Bacik) grubunda düzenlenen bootcamp programý.",
                        SubSkills = new List<GetSubSkillModel>()
                        {
                            new GetSubSkillModel()
                            {
                                Id= Guid.NewGuid(),
                                Name = "C#"
                            },
                            new GetSubSkillModel()
                            {
                                Id= Guid.NewGuid(),
                                Name = ".NET API"
                            },
                            new GetSubSkillModel()
                            {
                                Id= Guid.NewGuid(),
                                Name = "SeriLog"
                            },
                            new GetSubSkillModel()
                            {
                                Id= Guid.NewGuid(),
                                Name = "MemoryCache"
                            },
                            new GetSubSkillModel()
                            {
                                Id= Guid.NewGuid(),
                                Name = "Middleware"
                            },
                            new GetSubSkillModel()
                            {
                                Id= Guid.NewGuid(),
                                Name = "CQRS"
                            },
                            new GetSubSkillModel()
                            {
                                Id= Guid.NewGuid(),
                                Name = "Redis"
                            },
                            new GetSubSkillModel()
                            {
                                Id= Guid.NewGuid(),
                                Name = "RabbitMQ"
                            },
                            new GetSubSkillModel()
                            {
                                Id= Guid.NewGuid(),
                                Name = "gRPC"
                            },
                            new GetSubSkillModel()
                            {
                                Id= Guid.NewGuid(),
                                Name = "Microservice"
                            }
                        }
                    },
                    new GetExperienceWithTechnologyAndTypeModel()
                    {
                        Id = Guid.NewGuid(),
                        StartDate = DateTime.Parse("01-12-2024"),
                        ExperienceType = calisma,
                        Provider = "",
                        Title = "NTN Yazýlým - Full Stack Developer",
                        Reference = "",
                        Description = "NTN Yazýlým Þirketinde Fullstack Developer Olarak Çalýþýyorum.",
                        SubSkills = new List<GetSubSkillModel>()
                        {
                            new GetSubSkillModel()
                            {
                                Id= Guid.NewGuid(),
                                Name = "C#"
                            },
                            new GetSubSkillModel()
                            {
                                Id= Guid.NewGuid(),
                                Name = ".NET API"
                            },
                            new GetSubSkillModel()
                            {
                                Id= Guid.NewGuid(),
                                Name = "Ef Core"
                            },
                            new GetSubSkillModel()
                            {
                                Id= Guid.NewGuid(),
                                Name = "Sql Server"
                            },
                            new GetSubSkillModel()
                            {
                                Id= Guid.NewGuid(),
                                Name = "JWT"
                            },
                            new GetSubSkillModel()
                            {
                                Id= Guid.NewGuid(),
                                Name = "Postman"
                            },
                            new GetSubSkillModel()
                            {
                                Id= Guid.NewGuid(),
                                Name = "Git"
                            },
                            new GetSubSkillModel()
                            {
                                Id= Guid.NewGuid(),
                                Name = "Javascript"
                            },
                            new GetSubSkillModel()
                            {
                                Id= Guid.NewGuid(),
                                Name = "JQuery"
                            },
                            new GetSubSkillModel()
                            {
                                Id= Guid.NewGuid(),
                                Name = "Bootstrap"
                            }
                        }
                    }
                }
            };
            return View(new SuccessReturn<CvResponseModel>(cvResponseModel));
        }

        */
    }
}
