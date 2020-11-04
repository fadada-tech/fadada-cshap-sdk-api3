using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FDD.OpenAPI.Models
{
    public interface IbaseInput
    {
        string AppId
        {
            set;
            get;
        }
        string SignType
        {
            set;
            get;
        }
        string Sign
        {
            set;
            get;
        }
        string Timestamp
        {
            set;
            get;
        }
        string Nonce
        {
            set;
            get;
        }
        string Token
        {
            set;
            get;
        }
        string bizContent
        {
            set;
            get;
        }
    }
}
