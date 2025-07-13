using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TahaMucasirogluBlog.Domain.DTOs.Concrete.Entity.Experience;
using TahaMucasirogluBlog.Domain.DTOs.Concrete.Entity.ExperienceTechnology;
using TahaMucasirogluBlog.Domain.DTOs.Concrete.Entity.ExperienceType;
using TahaMucasirogluBlog.Domain.DTOs.Concrete.Entity.Info;
using TahaMucasirogluBlog.Domain.DTOs.Concrete.Entity.Skill;
using TahaMucasirogluBlog.Domain.DTOs.Concrete.Entity.SocialLink;
using TahaMucasirogluBlog.Domain.DTOs.Concrete.Entity.SubSkill;
using TahaMucasirogluBlog.Domain.DTOs.Concrete.Response;
using TahaMucasirogluBlog.Domain.Return.Concrete;
using TahaMucasirogluBlog.Service.Cv.Abstract;

namespace TahaMucasirogluBlog.Presentation.API.Controllers.Concrete
{
    [Route("api/[controller]")]
    [ApiController]
    public class CvController : ControllerBase
    {
        private readonly ICvService cvService;
        public CvController(ICvService cvService)
        {
            this.cvService = cvService;
        }


        [HttpGet("[action]")]
        public IActionResult Get()
        {
            return Ok(cvService.GetCV());
        }

        [HttpGet("[action]")]
        public IActionResult GetTest()
        {
            GetExperienceTypeDTO staj = new GetExperienceTypeDTO()
            {
                Id = Guid.NewGuid(),
                Name = "Staj"
            };

            GetExperienceTypeDTO gonullu = new GetExperienceTypeDTO()
            {
                Id = Guid.NewGuid(),
                Name = "Gönüllü"
            };
            GetExperienceTypeDTO calisma = new GetExperienceTypeDTO()
            {
                Id = Guid.NewGuid(),
                Name = "İş"
            };
            GetExperienceTypeDTO proje = new GetExperienceTypeDTO()
            {
                Id = Guid.NewGuid(),
                Name = "Proje"
            };
            GetExperienceTypeDTO egitim = new GetExperienceTypeDTO()
            {
                Id = Guid.NewGuid(),
                Name = "Eğitim"
            };

            CvResponseDTO cvResponseDTO = new CvResponseDTO()
            {
                Info = new GetInfoDTO()
                {
                    Id = Guid.NewGuid(),
                    Email = "tahamucasiroglu@gmail.com",
                    FullName = "Ahmet Taha Mücasiroğlu",
                    Location = "İstanbul - İzmir - Muğla/Fethiye - Ankara",
                    Phone = "553 735 62 89",
                },

                SocialLinks = new List<GetSocialLinkDTO>()
                {
                    new GetSocialLinkDTO()
                    {
                        Id = Guid.NewGuid(),
                        Name = "LinkedIn",
                        DisplayOrder = 1,
                        IconClass = "fa-brands fa-linkedin",
                        IsVisible = true,
                        Url = "https://www.linkedin.com/in/tahamucasiroglu/"
                    },
                    new GetSocialLinkDTO()
                    {
                        Id = Guid.NewGuid(),
                        Name = "Github",
                        DisplayOrder = 2,
                        IconClass = "fa-brands fa-github",
                        IsVisible = true,
                        Url = "https://github.com/tahamucasiroglu"
                    },
                    new GetSocialLinkDTO()
                    {
                        Id = Guid.NewGuid(),
                        Name = "Mail",
                        DisplayOrder = 3,
                        IconClass = "fa-solid fa-envelope",
                        IsVisible = true,
                        Url = "mailto:tahamucasiroglu@gmail.com"
                    },
                    new GetSocialLinkDTO()
                    {
                        Id = Guid.NewGuid(),
                        Name = "Telefon",
                        DisplayOrder = 4,
                        IconClass = "fa-solid fa-phone",
                        IsVisible = true,
                        Url = "tel:+905537356289"
                    }
                },

                Skills = new List<GetSkillWithSubSkillsDTO>()
                {
                    new GetSkillWithSubSkillsDTO()
                    {
                        Id = Guid.NewGuid(),
                        Name = "Backend",
                        SubSkills = new List<GetSubSkillDTO>()
                        {
                            new GetSubSkillDTO()
                            {
                                Id = Guid.NewGuid(),
                                Name = ".Net Api Core",
                            },
                            new GetSubSkillDTO()
                            {
                                Id = Guid.NewGuid(),
                                Name = "Ef Core",
                            },
                            new GetSubSkillDTO()
                            {
                                Id = Guid.NewGuid(),
                                Name = "PostgreSQL",
                            },
                            new GetSubSkillDTO()
                            {
                                Id = Guid.NewGuid(),
                                Name =  "Sql Server / Sql Express",
                            },
                            new GetSubSkillDTO()
                            {
                                Id = Guid.NewGuid(),
                                Name = "Dapper",
                            }
                        }
                    },
                    new GetSkillWithSubSkillsDTO()
                    {
                        Id = Guid.NewGuid(),
                        Name = "Mobile",
                        SubSkills = new List<GetSubSkillDTO>()
                        {
                            new GetSubSkillDTO()
                            {
                                Id = Guid.NewGuid(),
                                Name = "Flutter",
                            },
                            new GetSubSkillDTO()
                            {
                                Id = Guid.NewGuid(),
                                Name = "Dart",
                            },
                            new GetSubSkillDTO()
                            {
                                Id = Guid.NewGuid(),
                                Name = "Rest API",
                            }
                        }
                    },
                    new GetSkillWithSubSkillsDTO()
                    {
                        Id = Guid.NewGuid(),
                        Name = "Frontend",
                        SubSkills = new List<GetSubSkillDTO>()
                        {
                            new GetSubSkillDTO()
                            {
                                Id = Guid.NewGuid(),
                                Name = ".NET MVC",
                            },
                            new GetSubSkillDTO()
                            {
                                Id = Guid.NewGuid(),
                                Name = "Javascript",
                            },
                            new GetSubSkillDTO()
                            {
                                Id = Guid.NewGuid(),
                                Name = "JQuery",
                            },
                            new GetSubSkillDTO()
                            {
                                Id = Guid.NewGuid(),
                                Name =  "React",
                            },
                            new GetSubSkillDTO()
                            {
                                Id = Guid.NewGuid(),
                                Name = "Bootstrap",
                            }
                        }
                    },
                    new GetSkillWithSubSkillsDTO()
                    {
                        Id = Guid.NewGuid(),
                        Name = "Other",
                        SubSkills = new List<GetSubSkillDTO>()
                        {
                            new GetSubSkillDTO()
                            {
                                Id = Guid.NewGuid(),
                                Name = "Python",
                            },
                            new GetSubSkillDTO()
                            {
                                Id = Guid.NewGuid(),
                                Name = "Script",
                            },
                            new GetSubSkillDTO()
                            {
                                Id = Guid.NewGuid(),
                                Name = "Web Scraping",
                            },
                            new GetSubSkillDTO()
                            {
                                Id = Guid.NewGuid(),
                                Name =  "Tensorflow",
                            },
                            new GetSubSkillDTO()
                            {
                                Id = Guid.NewGuid(),
                                Name = "Clean Arch",
                            },
                            new GetSubSkillDTO()
                            {
                                Id = Guid.NewGuid(),
                                Name =  "CQRS",
                            },
                            new GetSubSkillDTO()
                            {
                                Id = Guid.NewGuid(),
                                Name = "Git",
                            }
                        }
                    }
                },
                Experiences = new List<GetExperienceWithTechnologyAndTypeDTO>()
                {
                    new GetExperienceWithTechnologyAndTypeDTO()
                    {
                        Id = Guid.NewGuid(),
                        StartDate = DateTime.Parse("01-07-2019"),
                        EndDate = DateTime.Parse("01-08-2019"),
                        ExperienceType = staj,
                        Provider = "",
                        Title = "Seydikemer Belediyesi Bilgi İşlem",
                        Reference = "",
                        Description = "Kamu kurumunda teknik destek sağladım. Program kurulumu, kullanıcı desteği,arıza tespiti ve çözüm süreçlerinde doğrudan sahada görev aldım.",
                        SubSkills = new List<GetSubSkillDTO>()
                        {
                            new GetSubSkillDTO()
                            {
                                Id= Guid.NewGuid(),
                                Name = "Teknik Destek"
                            },
                            new GetSubSkillDTO()
                            {
                                Id= Guid.NewGuid(),
                                Name = "Kullanıcı Memnuniyeti"
                            },
                            new GetSubSkillDTO()
                            {
                                Id= Guid.NewGuid(),
                                Name = "Problem Çözme"
                            },
                        }
                    },
                    new GetExperienceWithTechnologyAndTypeDTO()
                    {
                        Id = Guid.NewGuid(),
                        StartDate = DateTime.Parse("01-11-2020"),
                        EndDate = DateTime.Parse("01-11-2020"),
                        ExperienceType = proje,
                        Provider = "",
                        Title = "Ayşe Tatile Çıksın - Şifreli Mesajlaşma",
                        Reference = "",
                        Description = "RSA şifreleme ile arada sunucu olmadan, doğrudan P2P iletişim yapan şifreli mesaşlaşma uygulaması.",
                        SubSkills = new List<GetSubSkillDTO>()
                        {
                            new GetSubSkillDTO()
                            {
                                Id= Guid.NewGuid(),
                                Name = "Cryptology"
                            },
                            new GetSubSkillDTO()
                            {
                                Id= Guid.NewGuid(),
                                Name = "Python"
                            },
                            new GetSubSkillDTO()
                            {
                                Id= Guid.NewGuid(),
                                Name = "Socket"
                            },
                            new GetSubSkillDTO()
                            {
                                Id= Guid.NewGuid(),
                                Name = "Thread"
                            },
                            new GetSubSkillDTO()
                            {
                                Id= Guid.NewGuid(),
                                Name = "Tkinter"
                            },
                            new GetSubSkillDTO()
                            {
                                Id= Guid.NewGuid(),
                                Name = "RSA"
                            },
                        }
                    },
                    new GetExperienceWithTechnologyAndTypeDTO()
                    {
                        Id = Guid.NewGuid(),
                        StartDate = DateTime.Parse("01-06-2021"),
                        EndDate = DateTime.Parse("01-12-2021"),
                        ExperienceType = staj,
                        Provider = "",
                        Title = "NTN Yazılım - Mobil Uygulama Geliştirici",
                        Reference = "",
                        Description = "Atık toplama tesisi için geliştirilen, mobil ve tablet cihazlarda kullanılacak Flutter tabanlı uygulamanın geliştirilmesinde görev aldım.",
                        SubSkills = new List<GetSubSkillDTO>()
                        {
                            new GetSubSkillDTO()
                            {
                                Id= Guid.NewGuid(),
                                Name = "Flutter"
                            },
                            new GetSubSkillDTO()
                            {
                                Id= Guid.NewGuid(),
                                Name = "Dart"
                            },
                            new GetSubSkillDTO()
                            {
                                Id= Guid.NewGuid(),
                                Name = "RESTful API"
                            },
                            new GetSubSkillDTO()
                            {
                                Id= Guid.NewGuid(),
                                Name = "Layered Architecture"
                            },
                        }
                    },
                    new GetExperienceWithTechnologyAndTypeDTO()
                    {
                        Id = Guid.NewGuid(),
                        StartDate = DateTime.Parse("01-09-2021"),
                        EndDate = DateTime.Parse("01-06-2022"),
                        ExperienceType = proje,
                        Provider = "",
                        Title = "TTB10 - Deepfake Video Tespiti",
                        Reference = "",
                        Description = "Tez projemiz için ürettiğimiz deepfake video tespiti. Hedef verisetinde %82'lik başarı oranı ile tamamlandı.",
                        SubSkills = new List<GetSubSkillDTO>()
                        {
                            new GetSubSkillDTO()
                            {
                                Id= Guid.NewGuid(),
                                Name = "Python"
                            },
                            new GetSubSkillDTO()
                            {
                                Id= Guid.NewGuid(),
                                Name = "Tensorflow"
                            },
                            new GetSubSkillDTO()
                            {
                                Id= Guid.NewGuid(),
                                Name = "Cuda"
                            },
                            new GetSubSkillDTO()
                            {
                                Id= Guid.NewGuid(),
                                Name = "OpenCV"
                            },
                            new GetSubSkillDTO()
                            {
                                Id= Guid.NewGuid(),
                                Name = "CNN(Convolutional Neural Networks)"
                            },
                            new GetSubSkillDTO()
                            {
                                Id= Guid.NewGuid(),
                                Name = "Pandas"
                            },
                        }
                    },
                    new GetExperienceWithTechnologyAndTypeDTO()
                    {
                        Id = Guid.NewGuid(),
                        StartDate = DateTime.Parse("01-12-2022"),
                        EndDate = DateTime.Parse("01-04-2023"),
                        ExperienceType = gonullu,
                        Provider = "",
                        Title = "Bitranium Blockchain",
                        Reference = "",
                        Description = "Bitranium kripto para uygulamasında kısa süreli gönüllü çalışma sağladım. Proje sonradan kapandı.",
                        SubSkills = new List<GetSubSkillDTO>()
                        {
                            new GetSubSkillDTO()
                            {
                                Id= Guid.NewGuid(),
                                Name = "WEB3"
                            },
                            new GetSubSkillDTO()
                            {
                                Id= Guid.NewGuid(),
                                Name = "Blockchain"
                            },
                            new GetSubSkillDTO()
                            {
                                Id= Guid.NewGuid(),
                                Name = "React"
                            },
                            new GetSubSkillDTO()
                            {
                                Id= Guid.NewGuid(),
                                Name = "Solidity"
                            },
                            new GetSubSkillDTO()
                            {
                                Id= Guid.NewGuid(),
                                Name = "Contracts"
                            }
                        }
                    },
                    new GetExperienceWithTechnologyAndTypeDTO()
                    {
                        Id = Guid.NewGuid(),
                        StartDate = DateTime.Parse("01-02-2023"),
                        EndDate = DateTime.Parse("01-07-2023"),
                        ExperienceType = egitim,
                        Provider = "",
                        Title = "Turkcell Bootcamp",
                        Reference = "",
                        Description = "Turkcell GYGY 2023 C# .NET Bootcamp eğitimi. Başarıyla tamamlandı.",
                        SubSkills = new List<GetSubSkillDTO>()
                        {
                            new GetSubSkillDTO()
                            {
                                Id= Guid.NewGuid(),
                                Name = "C#"
                            },
                            new GetSubSkillDTO()
                            {
                                Id= Guid.NewGuid(),
                                Name = ".NET API"
                            },
                            new GetSubSkillDTO()
                            {
                                Id= Guid.NewGuid(),
                                Name = "Architecture"
                            },
                            new GetSubSkillDTO()
                            {
                                Id= Guid.NewGuid(),
                                Name = "Algorithm"
                            }
                        }
                    },
                    new GetExperienceWithTechnologyAndTypeDTO()
                    {
                        Id = Guid.NewGuid(),
                        StartDate = DateTime.Parse("01-07-2023"),
                        EndDate = DateTime.Parse("01-08-2023"),
                        ExperienceType = staj,
                        Provider = "",
                        Title = "Atmosware Backend Developer",
                        Reference = "",
                        Description = "Turkcell Bootcamp sonrası Atmosware şirketinde 1 ay süren staj programı.",
                        SubSkills = new List<GetSubSkillDTO>()
                        {
                            new GetSubSkillDTO()
                            {
                                Id= Guid.NewGuid(),
                                Name = "C#"
                            },
                            new GetSubSkillDTO()
                            {
                                Id= Guid.NewGuid(),
                                Name = ".NET API"
                            },
                            new GetSubSkillDTO()
                            {
                                Id= Guid.NewGuid(),
                                Name = ".NET MVC"
                            },
                            new GetSubSkillDTO()
                            {
                                Id= Guid.NewGuid(),
                                Name = "React"
                            },
                            new GetSubSkillDTO()
                            {
                                Id= Guid.NewGuid(),
                                Name = "PostgreSQL"
                            },
                            new GetSubSkillDTO()
                            {
                                Id= Guid.NewGuid(),
                                Name = "SOLID"
                            },
                            new GetSubSkillDTO()
                            {
                                Id= Guid.NewGuid(),
                                Name = "DI"
                            }
                        }
                    },
                    new GetExperienceWithTechnologyAndTypeDTO()
                    {
                        Id = Guid.NewGuid(),
                        StartDate = DateTime.Parse("01-04-2024"),
                        EndDate = DateTime.Parse("01-08-2024"),
                        ExperienceType = egitim,
                        Provider = "",
                        Title = "HWA .NET Bootcamp",
                        Reference = "",
                        Description = "HWA (Veli Bacik) grubunda düzenlenen bootcamp programı.",
                        SubSkills = new List<GetSubSkillDTO>()
                        {
                            new GetSubSkillDTO()
                            {
                                Id= Guid.NewGuid(),
                                Name = "C#"
                            },
                            new GetSubSkillDTO()
                            {
                                Id= Guid.NewGuid(),
                                Name = ".NET API"
                            },
                            new GetSubSkillDTO()
                            {
                                Id= Guid.NewGuid(),
                                Name = "SeriLog"
                            },
                            new GetSubSkillDTO()
                            {
                                Id= Guid.NewGuid(),
                                Name = "MemoryCache"
                            },
                            new GetSubSkillDTO()
                            {
                                Id= Guid.NewGuid(),
                                Name = "Middleware"
                            },
                            new GetSubSkillDTO()
                            {
                                Id= Guid.NewGuid(),
                                Name = "CQRS"
                            },
                            new GetSubSkillDTO()
                            {
                                Id= Guid.NewGuid(),
                                Name = "Redis"
                            },
                            new GetSubSkillDTO()
                            {
                                Id= Guid.NewGuid(),
                                Name = "RabbitMQ"
                            },
                            new GetSubSkillDTO()
                            {
                                Id= Guid.NewGuid(),
                                Name = "gRPC"
                            },
                            new GetSubSkillDTO()
                            {
                                Id= Guid.NewGuid(),
                                Name = "Microservice"
                            }
                        }
                    },
                    new GetExperienceWithTechnologyAndTypeDTO()
                    {
                        Id = Guid.NewGuid(),
                        StartDate = DateTime.Parse("01-12-2024"),
                        ExperienceType = calisma,
                        Provider = "",
                        Title = "NTN Yazılım - Full Stack Developer",
                        Reference = "",
                        Description = "NTN Yazılım Şirketinde Fullstack Developer Olarak Çalışıyorum.",
                        SubSkills = new List<GetSubSkillDTO>()
                        {
                            new GetSubSkillDTO()
                            {
                                Id= Guid.NewGuid(),
                                Name = "C#"
                            },
                            new GetSubSkillDTO()
                            {
                                Id= Guid.NewGuid(),
                                Name = ".NET API"
                            },
                            new GetSubSkillDTO()
                            {
                                Id= Guid.NewGuid(),
                                Name = "Ef Core"
                            },
                            new GetSubSkillDTO()
                            {
                                Id= Guid.NewGuid(),
                                Name = "Sql Server"
                            },
                            new GetSubSkillDTO()
                            {
                                Id= Guid.NewGuid(),
                                Name = "JWT"
                            },
                            new GetSubSkillDTO()
                            {
                                Id= Guid.NewGuid(),
                                Name = "Postman"
                            },
                            new GetSubSkillDTO()
                            {
                                Id= Guid.NewGuid(),
                                Name = "Git"
                            },
                            new GetSubSkillDTO()
                            {
                                Id= Guid.NewGuid(),
                                Name = "Javascript"
                            },
                            new GetSubSkillDTO()
                            {
                                Id= Guid.NewGuid(),
                                Name = "JQuery"
                            },
                            new GetSubSkillDTO()
                            {
                                Id= Guid.NewGuid(),
                                Name = "Bootstrap"
                            }
                        }
                    }
                }
            };
            return Ok(new SuccessReturn<CvResponseDTO>(cvResponseDTO));
        }








    }
}
