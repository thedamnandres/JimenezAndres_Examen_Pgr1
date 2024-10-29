using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using JimenezAndres_Examen_Pgr1.Models;

namespace JimenezAndres_Examen_Pgr1.Data
{
    public class JimenezAndres_Examen_Pgr1Context : DbContext
    {
        public JimenezAndres_Examen_Pgr1Context (DbContextOptions<JimenezAndres_Examen_Pgr1Context> options)
            : base(options)
        {
        }

        public DbSet<JimenezAndres_Examen_Pgr1.Models.AJimenez> AJimenez { get; set; } = default!;
        public DbSet<JimenezAndres_Examen_Pgr1.Models.Celular> Celular { get; set; } = default!;
    }
}
