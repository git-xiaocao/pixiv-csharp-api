using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PixivAPI.Http
{
    internal class FormData : MultipartFormDataContent
    {
        public object? this[string name]
        {
            set
            {
                if (value is string @string)
                {
                    Add(new StringContent(@string), name);
                }
                else if (value is int @int)
                {
                    Add(new StringContent(@int.ToString()), name);
                }
                else if (value is bool @bool)
                {
                    Add(new StringContent(@bool ? "true" : "false"), name);
                }
                else
                {
                    throw new ArgumentException("查询参数只能是string int bool类型");
                }
            }

        }

    }
}
