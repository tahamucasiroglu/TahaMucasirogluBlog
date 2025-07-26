using AutoMapper;
using TahaMucasiroglu.Domain.DTOs.Abstract;
using TahaMucasiroglu.Domain.Entities.Abstract;

namespace TahaMucasiroglu.Application.Mapper.Extensions.ConfigExtension
{
    static public class ConfigExtension
    {
        /// <summary>
        /// Bir nesnenin ekleme (insert) işlemi için varsayılan haritalama konfigürasyonunu ayarlar.
        /// </summary>
        /// <typeparam name="TDest">Hedef DTO türü. <see cref="IAddDTO"/> arayüzünü uygulamalıdır.</typeparam>
        /// <typeparam name="TSrc">Kaynak Entity türü. <see cref="IEntity"/> arayüzünü uygulamalıdır.</typeparam>
        /// <param name="mapper">IMappingExpression nesnesi.</param>
        /// <returns>IMappingExpression nesnesi.</returns>
        static public IMappingExpression<TDest, TSrc> DefaultAddMapConfig<TDest, TSrc>(this IMappingExpression<TDest, TSrc> mapper)
            where TDest : IAddDTO
            where TSrc : IEntity
            => mapper
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Guid.NewGuid()))
            .ForMember(dest => dest.InsertedAt, opt => opt.MapFrom(src => DateTime.UtcNow))
            .ForMember(dest => dest.InsertedBy, opt => opt.MapFrom(src => src.IslemYapanKullaniciId))
            .ForMember(dest => dest.IsDeleted, opt => opt.MapFrom(src => false));
        /// <summary>
        /// Bir nesnenin güncelleme (update) işlemi için varsayılan haritalama konfigürasyonunu ayarlar.
        /// </summary>
        /// <typeparam name="TDest">Hedef DTO türü. <see cref="IUpdateDTO"/> arayüzünü uygulamalıdır.</typeparam>
        /// <typeparam name="TSrc">Kaynak Entity türü. <see cref="IEntity"/> arayüzünü uygulamalıdır.</typeparam>
        /// <param name="mapper">IMappingExpression nesnesi.</param>
        /// <returns>IMappingExpression nesnesi.</returns>
        static public IMappingExpression<TDest, TSrc> DefaultUpdateMapConfig<TDest, TSrc>(this IMappingExpression<TDest, TSrc> mapper)
            where TDest : IUpdateDTO
            where TSrc : IEntity
            => mapper
            .ForMember(dest => dest.UpdatedAt, src => src.MapFrom(src => DateTime.UtcNow))
            .ForMember(dest => dest.UpdatedBy, src => src.MapFrom(src => src.IslemYapanKullaniciId));
        /// <summary>
        /// Bir nesnenin silme (delete) işlemi için varsayılan haritalama konfigürasyonunu ayarlar.
        /// </summary>
        /// <typeparam name="TDest">Hedef DTO türü. <see cref="IDeleteDTO"/> arayüzünü uygulamalıdır.</typeparam>
        /// <typeparam name="TSrc">Kaynak Entity türü. <see cref="IEntity"/> arayüzünü uygulamalıdır.</typeparam>
        /// <param name="mapper">IMappingExpression nesnesi.</param>
        /// <returns>IMappingExpression nesnesi.</returns>
        static public IMappingExpression<TDest, TSrc> DefaultDeleteMapConfig<TDest, TSrc>(this IMappingExpression<TDest, TSrc> mapper)
            where TDest : IDeleteDTO
            where TSrc : IEntity
            => mapper
            .ForMember(dest => dest.DeletedAt, src => src.MapFrom(src => DateTime.UtcNow))
            .ForMember(dest => dest.DeletedBy, opt => opt.MapFrom(src => src.IslemYapanKullaniciId))
            .ForMember(dest => dest.IsDeleted, src => src.MapFrom(src => true));
    }
}
