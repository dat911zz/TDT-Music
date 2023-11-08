using Newtonsoft.Json;
using System.Collections.Generic;
using System;
using TDT.Core.Models;
using System.Linq;
using System.Reflection;
using TDT.Core.DTO.Firestore;

namespace TDT.Core.Helper
{
    public class ConvertService
    {
        private static ConvertService _instance;
        private ConvertService() { }
        public static ConvertService Instance
        {
            get
            {
                if(_instance == null )
                {
                    _instance = new ConvertService();
                }
                return _instance;
            }
        }

        
        public UserIdentiyModel convertToUserDetailDTO(User user)
        {
            return new UserIdentiyModel
            {
                UserName = user.UserName,
                Address = user.Address,
                PhoneNumber = user.PhoneNumber,
                Email = user.Email,
                Password = user.PasswordHash
            };
        }
        public T convertToObjectFromJson<T>(string json) where T : class
        {
            return JsonConvert.DeserializeObject<T>(json);
        }
        public T convertToObjectFromDictionary<T>(IDictionary<string, object> dictionary) where T : class, new()
        {
            if(dictionary != null )
            {
                var res = new T();
                var someObjectType = res.GetType();
                foreach (var item in dictionary)
                {
                    if (item.Value != null)
                    {
                        Type t = item.Value.GetType();
                        if (t == typeof(List<object>))
                        {
                            string typeItem = (someObjectType.GetProperty(item.Key)).ToString();
                            if (typeItem.Contains("System.String"))
                            {
                                someObjectType
                                 .GetProperty(item.Key)
                                 .SetValue(res, ((List<object>)item.Value).Select(i => i.ToString()).ToList(), null);
                            }
                            else if ((someObjectType.GetProperty(item.Key)).ToString().Contains("SectionDTO"))
                            {
                                List<SectionDTO> sections = new List<SectionDTO>();
                                ((List<object>)item.Value).ForEach(o => sections.Add(convertToObjectFromDictionary<SectionDTO>((IDictionary<string, object>)o)));
                                someObjectType
                                    .GetProperty(item.Key)
                                    .SetValue(res, sections, null);
                            }
                            else
                            {
                                someObjectType
                                     .GetProperty(item.Key)
                                     .SetValue(res, item.Value, null);
                            }
                        }
                        else if (t == typeof(Int64))
                        {
                            if(item.Value.ToString().Length > int.MaxValue.ToString().Length)
                            {
                                someObjectType
                                 .GetProperty(item.Key)
                                 .SetValue(res, long.Parse(item.Value.ToString()), null);
                            }
                            else
                            {
                                if(someObjectType.GetProperty(item.Key).PropertyType.Name.ToLower().Contains("string"))
                                {
                                    someObjectType
                                     .GetProperty(item.Key)
                                     .SetValue(res, item.Value.ToString(), null);
                                }
                                else
                                {
                                    someObjectType
                                     .GetProperty(item.Key)
                                     .SetValue(res, int.Parse(item.Value.ToString()), null);
                                }
                            }
                        }
                        else
                        {
                            if ((someObjectType.GetProperty(item.Key)).ToString().Contains("Genre"))
                            {
                                Genre genre = convertToObjectFromDictionary<Genre>((IDictionary<string, object>)item.Value);
                                someObjectType
                                    .GetProperty(item.Key)
                                    .SetValue(res, genre, null);
                            }
                            else
                            {
                                someObjectType
                                 .GetProperty(item.Key)
                                 .SetValue(res, item.Value, null);
                            }
                        }
                    }
                }
                return res;
            }
            return null;
        }
    }
}
