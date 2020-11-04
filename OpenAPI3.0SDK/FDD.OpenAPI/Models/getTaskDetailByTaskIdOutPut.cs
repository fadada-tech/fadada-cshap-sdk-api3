using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FDD.OpenAPI.Models
{
   public class getTaskDetailByTaskIdOutPut:baseOutput
    {
        public getTaskDetailByTaskIddata data
        {
            set;
            get;
        }
    }
    public class getTaskDetailByTaskIddata
    {
        public string taskId
        {
            set;
            get;
        }
        public string taskSubject
        {
            set;
            get;
        }
        public int taskStatus
        {
            set;
            get;
        }
        public List<taskDetails> taskDetails
        {
            set;
            get;
        }
    }
    public class taskDetails
    {
        public string unionId
        {
            set;
            get;
        }
        public string signStatus
        {
            set;
            get;
        }
        public string resultDesc
        {
            set;
            get;
        }
    }
}
