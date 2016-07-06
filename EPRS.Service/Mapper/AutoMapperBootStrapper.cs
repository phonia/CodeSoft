using AutoMapper;
using ERPS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EPRS.Service
{
    public class AutoMapperBootStrapper
    {
        //public static void Start()
        //{
        //    Mapper.CreateMap<MSUserDTO, MSUser>()
        //        .ForMember(d => d.ContactNumber, opt => opt.MapFrom(s => s.ContactNumber))
        //        .ForMember(d => d.Email, opt => opt.MapFrom(s => s.ContactNumber))
        //        .ForMember(d => d.MSRole, opt => opt.MapFrom(s => (int)s.MSRole))
        //        .ForMember(d => d.Name, opt => opt.MapFrom(s => s.Name))
        //        .ForMember(d => d.Pwd, opt => opt.MapFrom(s => s.Pwd))
        //        .ForMember(d=>d.MSImage,opt=>opt.MapFrom(s=>new byte[1]))
        //        .ForMember(d => d.Sex, opt => opt.MapFrom(s => (int)s.Sex));
        //    Mapper.CreateMap<MSUser, MSUserDTO>()
        //        .ForMember(d => d.ContactNumber, opt => opt.MapFrom(s => s.ContactNumber))
        //        .ForMember(d => d.Email, opt => opt.MapFrom(s => s.ContactNumber))
        //        .ForMember(d => d.MSRole, opt => opt.MapFrom(s => (int)s.MSRole))
        //        .ForMember(d => d.Name, opt => opt.MapFrom(s => s.Name))
        //        .ForMember(d => d.Pwd, opt => opt.MapFrom(s => s.Pwd))
        //        .ForMember(d => d.MSImage, opt => opt.MapFrom(s=>Convert.ToBase64String(s.MSImage)))
        //        .ForMember(d => d.Sex, opt => opt.MapFrom(s => (int)s.Sex));
        //}
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
            if (source == null) return default(TResult);
            if (Mapper.FindTypeMapFor(typeof(TSource), typeof(TResult)) != null)
            {
                return Mapper.Map<TSource, TResult>(source);
            }
            return default(TResult);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="source"></param>
        /// <returns>Return IEnumerable<TResult></TResult></returns>
        public static IEnumerable<TResult> MapperTo<TSource, TResult>(this IEnumerable<TSource> source)
        {
            if (source == null) return new List<TResult>();
            if (Mapper.FindTypeMapFor(typeof(TSource), typeof(TResult)) != null)
            {
                return Mapper.Map<IEnumerable<TSource>, IEnumerable<TResult>>(source);
            }
            return new List<TResult>();
        }
    }
}
