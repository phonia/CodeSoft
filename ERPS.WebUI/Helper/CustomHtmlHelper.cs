using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;

namespace ERPS.WebUI.Helper
{
    public static class CustomHtmlHelper
    {
        static String GetPropertyName<TModel, TProperty>(Expression<Func<TModel, TProperty>> expression)
        {
            MemberExpression me = expression.Body as MemberExpression;
            return me.Member.Name.ToString();
        }

        static String GetPropertyDescription<TModel, TProperty>(Expression<Func<TModel, TProperty>> expression)
        {
            MemberExpression me = expression.Body as MemberExpression;
            var declaringType = me.Member.DeclaringType;
            String propertyName = me.Member.Name.ToString();
            var property = declaringType.GetProperty(propertyName);
            var descrptionAttr = property.GetCustomAttributes(typeof(DescriptionAttribute), false);
            String description = (descrptionAttr.First() as DescriptionAttribute).Description;
            if (description.Contains('('))
            {
                description = description.Substring(0, description.IndexOf('('));
            }
            if (description.Contains("("))
            {
                description = description.Substring(0, description.IndexOf("("));
            }
            if (description.Contains("（"))
            {
                description = description.Substring(0, description.IndexOf("（"));
            }
            return description;
        }

        public static MvcHtmlString CSInputField<TModel, TProperty>(this HtmlHelper<TModel> html, Expression<Func<TModel, TProperty>> expression, String validType = "unnormal", bool required = true)
        {
            String inputLabel = String.Format("<label style=\"display:inline-block;width:100px;text-align:right\">{1}：</label>\n"
                    +"<input class=\"easyui-validatebox\" name=\"{0}\" data-options=\"required:{2},validType:'{3}'\" />\n"
                    +"<div style=\"height:10px\"></div>"
                ,GetPropertyName(expression),GetPropertyDescription(expression),required.ToString().ToLower(),validType);
            return new  MvcHtmlString(inputLabel);
        }

        public static MvcHtmlString CSInputComboBox<TModel, TProperty>(this HtmlHelper<TModel> html, Expression<Func<TModel, TProperty>> expression)
        {
            String str = String.Format("<label style=\"display:inline-block;width:100px;text-align:right\">{1}：</label>\n"
                    +"<input id=\"{0}\" name=\"{0}\" data-options=\"required:true,editable:false,panelHeight:'auto'\" />\n"
                    +"<div style=\"height:10px\"></div>",GetPropertyName(expression),GetPropertyDescription(expression));
            return new MvcHtmlString(str);
        }

        public static MvcHtmlString CSInputDateBox<TModel, TProperty>(this HtmlHelper<TModel> html, Expression<Func<TModel, TProperty>> expression)
        {
            String str = String.Format("<label style=\"display:inline-block;width:100px;text-align:right\">{1}：</label>\n"
                +"<input name=\"{0}\" type=\"text\" class=\"easyui-datebox\" data-options=\"required:true\" />"
                +"<div style=\"height:10px\"></div>",GetPropertyName(expression),GetPropertyDescription(expression));
            return new MvcHtmlString(str);
        }
    }
}