using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//namespace DTO
//{
//  public static class ListDTO<T,U> where  T : IDtoAble<T,U>
//   {
//       public static List<T> cToDTO(List<IDtoAble<T,U>> data)
//        {
//            IDtoAble<T, U> temp = ;
//            List<T>  list=new List<T>();
//            foreach (IDtoAble<T,U> item in data)
//            {
//              list.Add(item.cToDTO((U)item));
//            }
//            return list;
//        }
//     public  static List<U> DTOToC(List<IDtoAble<T, U>> data)
//        {
//                List<U> list = new List<U>();
//                foreach (IDtoAble<T, U> item in data)
//                {
//                    list.Add(item.DTOToC((T)item));
//                }
//                return list;
            
//        }
//   }
//}
