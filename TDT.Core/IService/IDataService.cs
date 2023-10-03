using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDT.Core.IService
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IDataService<T> where T : class
    {
        public List<T> GetDetails();
        public T GetDetails(int id);
        public void Add(T obj);
        public void Update(T obj);
        public T Delete(int id);
        public bool Check(int id);
    }
}
