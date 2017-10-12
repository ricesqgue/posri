using PosRi.DataAccess.Context;
using PosRi.DataAccess.Model;
using System.Data.Entity.Migrations;

namespace PosRi.DataAccess.Seeder
{
    public static class MexicanStatesSeeder
    {
        public static void Seed(PosRiContext dbContext)
        {
            dbContext.States.AddOrUpdate(
                s => s.Id,
                new State(1, "Aguascalientes"),
                new State(2, "Baja California"),
                new State(3, "Baja California Sur"),
                new State(4, "Campeche"),
                new State(5, "Coahuila de Zaragoza"),
                new State(6, "Colima"),
                new State(7, "Chiapas"),
                new State(8, "Chihuahua"),
                new State(9, "Distrito Federal"),
                new State(10, "Durango"),
                new State(11, "Guanajuato"),
                new State(12, "Guerrero"),
                new State(13, "Hidalgo"),
                new State(14, "Jalisco"),
                new State(15, "México"),
                new State(16, "Michoacán de Ocampo"),
                new State(17, "Morelos"),
                new State(18, "Nayarit"),
                new State(19, "Nuevo León"),
                new State(20, "Oaxaca de Juárez"),
                new State(21, "Puebla"),
                new State(22, "Querétaro"),
                new State(23, "Quintana Roo"),
                new State(24, "San Luis Potosí"),
                new State(25, "Sinaloa"),
                new State(26, "Sonora"),
                new State(27, "Tabasco"),
                new State(28, "Tamaulipas"),
                new State(29, "Tlaxcala"),
                new State(30, "Veracruz de Ignacio de la Llave"),
                new State(31, "Yucatán"),
                new State(32, "Zacatecas")
            );

            dbContext.SaveChanges();
        }
    }
}
