using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MED
{
    public class AppData
    {
        private static MEDEntities _context;
        public static MEDEntities db
        {
            get
            {
                if (_context == null)
                    _context = new MEDEntities();
                return _context;
            }
        }

        // Метод для сохранения изменений
        public static int SaveChanges()
        {
            return db.SaveChanges();
        }
    }
}
