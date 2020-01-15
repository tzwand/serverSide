using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class search
    {
        //מחלקה זו מיועדת לסנן לתורמים אילו ספרים מתאימים להם מתוך כל המבחר
        
        public IEnumerable<Book> perPayment(int payment)
        { 
            //פונקציה זו תחזיר את הספרים שמתאימים לתורם מבחינת המחיר 
           return data.getAllBooks().Where(sum => sum.Bookpayment <= payment);
        }
        
       
        public IEnumerable<Book> perParent(int id)
        {
            //פונקציה זו תחזיר את הספרים שמתאימים לספר האב אותו ביקש התורם  
           return data.getAllBooks().Where(Parent => Parent.ParentId <= id);
        }
        public Book perName(string name)
        {  
            //פונקציה זו תחזיר את הספר המתאים לפי שמו
            return data.getAllBooks().FirstOrDefault(n => n.BookName.Equals(name));
        }

    }
}
