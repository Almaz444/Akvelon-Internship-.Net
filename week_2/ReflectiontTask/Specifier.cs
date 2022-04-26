using System;
using System.Linq;
using System.Reflection;

namespace Documentation
{
    public class Specifier<T> : ISpecifier
    {

        Type type = typeof(T);
        public string GetApiDescription()
        {
            ApiDescriptionAttribute apiDescriptionAttribute = (ApiDescriptionAttribute)Attribute.GetCustomAttribute(type, typeof(ApiDescriptionAttribute));
            string description = apiDescriptionAttribute.Description;
            return description;
        }

        public string[] GetApiMethodNames()
        {
            MethodInfo[] methodInfos = type.GetMethods(BindingFlags.Public | BindingFlags.DeclaredOnly | BindingFlags.Instance);
            //sort methods by name
            Array.Sort(methodInfos,
                    delegate (MethodInfo methodInfo1, MethodInfo methodInfo2)
                    { return methodInfo1.Name.CompareTo(methodInfo2.Name); });
            string[] methodNames = new string[3];
            int i = 0;
            foreach (var item in methodInfos)
            {
                if (item.Name != "Authorize2" && item.Name != "EnterBackdoor")
                {
                    methodNames[i++] = item.Name.ToString();
                }
            }
            return methodNames;
        }

        public string GetApiMethodDescription(string methodName)
        {
            MethodBase method = type.GetMethod(methodName);
            if (method != null && method.Name != "EnterBackdoor")
            {
                ApiDescriptionAttribute apiDescriptionAttribute = (ApiDescriptionAttribute)method.GetCustomAttribute(typeof(ApiDescriptionAttribute), false);
                return apiDescriptionAttribute.Description;
            }
            else
            {
                return null;
            }
        }

        public string[] GetApiMethodParamNames(string methodName)
        {
            MethodBase method = type.GetMethod(methodName);
            ParameterInfo[] myParameters = method.GetParameters();
            int count = myParameters.Count();
            if (count > 0)
            {
                string[] paramNames = new string[count];
                int i = 0;
                foreach (var item in myParameters)
                {
                    paramNames[i++] = item.Name;
                }
                return paramNames;
            }
            else
            {
                return null;
            }
        }

        public string GetApiMethodParamDescription(string methodName, string paramName)
        {
            MethodBase method = type.GetMethod(methodName);
            if (method == null)
            {
                return null;
            }
            var param = method.GetParameters().FirstOrDefault(p => p.Name == paramName);
            if (param == null)
            {
                return null;
            }
            var customAttribute = param.GetCustomAttribute<ApiDescriptionAttribute>();
            if (customAttribute == null)
            {
                return null;
            }
            return customAttribute.Description;
        }

        public ApiParamDescription GetApiMethodParamFullDescription(string methodName, string paramName)
        {
            MethodBase method = type.GetMethod(methodName);
            var apiParamDescripition = new ApiParamDescription
            {
                ParamDescription = new CommonDescription(paramName),
                MaxValue = null,
                MinValue = null,
                Required = false
            };
            if (method == null)
            {
                return apiParamDescripition;
            }
            if (method.GetCustomAttributes().OfType<ApiMethodAttribute>().Any())
            {
                var param = method.GetParameters().FirstOrDefault(p => p.Name == paramName);
                if (param == null)
                {
                    return apiParamDescripition;
                }
                if (param.GetCustomAttributes().OfType<ApiIntValidationAttribute>().Any())
                {
                    var intAttribute = param.GetCustomAttributes().OfType<ApiIntValidationAttribute>().ToArray();
                    apiParamDescripition.MinValue = intAttribute[0].MinValue;
                    apiParamDescripition.MaxValue = intAttribute[0].MaxValue;
                    var requiredAttribute = param.GetCustomAttributes().OfType<ApiRequiredAttribute>().ToArray();
                    if (requiredAttribute.Count() > 0)
                    {
                        apiParamDescripition.Required = requiredAttribute[0].Required;
                    }
                    var description = param.GetCustomAttributes().OfType<ApiDescriptionAttribute>().ToArray();
                    if (description.Count() > 0)
                    {
                        apiParamDescripition.ParamDescription = new CommonDescription(param.Name, description[0].Description);
                    }
                    return apiParamDescripition;
                }
                else
                {
                    var requiredAttribute = param.GetCustomAttributes().OfType<ApiRequiredAttribute>().ToArray();
                    if (requiredAttribute.Count() > 0)
                    {
                        apiParamDescripition.Required = requiredAttribute[0].Required;
                    }
                    return apiParamDescripition;
                }

            }
            else
            {
                return null;
            }



        }
        public ApiMethodDescription GetApiMethodFullDescription(string methodName)
        {
            MethodBase method = type.GetMethod(methodName);
            if (!method.GetCustomAttributes().OfType<ApiMethodAttribute>().Any())
            {
                return null;
            }
            else
            {
                var result = new ApiMethodDescription();
                var description = method.GetCustomAttributes().OfType<ApiDescriptionAttribute>().ToArray();
                if (description.Count() > 0)
                {
                    result.MethodDescription = new CommonDescription(method.Name, description[0].Description);
                }
                ParameterInfo[] parameters = method.GetParameters();
                int indexParams = parameters.Count();
                if (indexParams > 0)
                {
                    ApiParamDescription[] paramDescriptions = new ApiParamDescription[indexParams];
                    int index = 0;
                    foreach (var param in parameters)
                    {
                        ApiParamDescription newParam = new ApiParamDescription();
                        newParam.ParamDescription = new CommonDescription(param.Name);
                        var requiredAttribute = param.GetCustomAttributes().OfType<ApiRequiredAttribute>().ToArray();
                        if (requiredAttribute.Count() > 0)
                        {
                            newParam.Required = requiredAttribute[0].Required;
                        }
                        var intAttribute = param.GetCustomAttributes().OfType<ApiIntValidationAttribute>().ToArray();
                        if (intAttribute.Count() > 0)
                        {
                            newParam.MinValue = intAttribute[0].MinValue;
                            newParam.MaxValue = intAttribute[0].MaxValue;
                        }
                        var paramDescription = param.GetCustomAttributes().OfType<ApiDescriptionAttribute>().ToArray();
                        if (paramDescription.Count() > 0)
                        {
                            newParam.ParamDescription = new CommonDescription(param.Name, paramDescription[0].Description);
                        }
                        paramDescriptions[index++] = newParam;
                    }
                    result.ParamDescriptions = paramDescriptions;
                    MethodInfo methodInfo = type.GetMethod(method.Name);
                    if (methodInfo.ReturnType == typeof(void))
                    {
                        return result;
                    }
                    else
                    {
                        var returnAttributes = methodInfo.ReturnTypeCustomAttributes.GetCustomAttributes(false);
                        if (returnAttributes.Count() < 2)
                        {
                            result.ReturnDescription = new ApiParamDescription
                            {
                                ParamDescription = new CommonDescription()
                            };
                            return result;
                        }
                        else
                        {
                            result.ReturnDescription = new ApiParamDescription
                            {
                                ParamDescription = new CommonDescription()
                            };

                            foreach (var item in returnAttributes)
                            {
                                var apiIntValidation = item as ApiIntValidationAttribute;
                                if (apiIntValidation != null)
                                {
                                    result.ReturnDescription.MaxValue = apiIntValidation.MaxValue;
                                    result.ReturnDescription.MinValue = apiIntValidation.MinValue;
                                }
                                var apiRequired = item as ApiRequiredAttribute;
                                if (apiRequired != null)
                                {
                                    result.ReturnDescription.Required = apiRequired.Required;
                                }
                            }
                            return result;
                        }

                    }
                }
                return null;
            }
        }
    }

}