using AutoMapper;
using ERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ERP.DService
{
    public class AutoMapperException : Exception
    { }

    public class AutoMapperBootStrapper
    {
        public static void Start()
        {
            Mapper.CreateMap<MSRight, MSRightDTO>()
                .ForMember(d => d.RightId, opt => opt.MapFrom(s => s.RightId.ToString()))
                .ForMember(d => d.ModuleId, opt => opt.MapFrom(s => s.MSModule.ModuleId.ToString()))
                .ForMember(d => d.ModuleName, opt => opt.MapFrom(s => s.MSModule.ModuleName))
                .ForMember(d => d.FuncId, opt => opt.MapFrom(s => s.MSFunc.FuncId.ToString()))
                .ForMember(d => d.FuncName, opt => opt.MapFrom(s => s.MSFunc.FuncName));
            //Mapper.CreateMap<MSRightDTO, MSRight>();
            Mapper.CreateMap<MSRole, MSRoleDTO>()
                .ForMember(d => d.RoleId, opt => opt.MapFrom(s => s.RoleId))
                .ForMember(d => d.RoleName, opt => opt.MapFrom(s => s.RoleName));
            Mapper.CreateMap<MSRoleDTO, MSRole>()
                .ForMember(d=>d.RoleId,opt=>opt.MapFrom(s=>s.RoleId))
                .ForMember(d=>d.RoleName,opt=>opt.MapFrom(s=>s.RoleName));
            Mapper.CreateMap<MSUser, MSUserDTO>()
                .ForMember(d=>d.UserId,opt=>opt.MapFrom(s=>s.UserId))
                .ForMember(d=>d.UserName,opt=>opt.MapFrom(s=>s.UserName))
                .ForMember(d=>d.Passworld,opt=>opt.MapFrom(s=>s.Password))
                .ForMember(d=>d.RoleName,opt=>opt.MapFrom(s=>s.MSRole.RoleName));
            Mapper.CreateMap<MSUserDTO, MSUser>()
                .ForMember(d=>d.UserId,opt=>opt.MapFrom(s=>s.UserId))
                .ForMember(d=>d.UserName,opt=>opt.MapFrom(s=>s.UserName))
                .ForMember(d=>d.Password,opt=>opt.MapFrom(s=>s.Passworld));
            Mapper.CreateMap<MSDomain,MSDomainDTO>()
                .ForMember(d=>d.DomainId,opt=>opt.MapFrom(s=>s.DomainId))
                .ForMember(d=>d.DomainName,opt=>opt.MapFrom(s=>s.DomainName));
            Mapper.CreateMap<MSModule, MSModuleDTO>()
                .ForMember(d=>d.ModuleUrl,opt=>opt.MapFrom(s=>s.ModuleUrl))
                .ForMember(d => d.ModuleId, opt => opt.MapFrom(s => s.ModuleId))
                .ForMember(d => d.ModuleName, opt => opt.MapFrom(s => s.ModuleName));
        }
    }

    public static class MapperHelper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="source"></param>
        /// <returns>Return TResult Instance or NUll</returns>
        public static TResult MapperTo<TSource, TResult>(this TSource source)
        {
            if (source == null) throw new AutoMapperException();
            if (Mapper.FindTypeMapFor(typeof(TSource), typeof(TResult)) != null)
            {
                return Mapper.Map<TSource,TResult>(source);
            }
            throw new AutoMapperException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="source"></param>
        /// <returns>Return IEnumerable<TResult> or NULL</TResult></returns>
        public static IEnumerable<TResult> MapperTo<TSource, TResult>(this IEnumerable<TSource> source)
        {
            if (source == null) throw new AutoMapperException();
            if (Mapper.FindTypeMapFor(typeof(TSource), typeof(TResult)) != null)
            {
                return Mapper.Map<IEnumerable<TSource>, IEnumerable<TResult>>(source);
            }
            throw new AutoMapperException();
        }
    }
}
