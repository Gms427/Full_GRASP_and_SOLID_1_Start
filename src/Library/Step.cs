//-------------------------------------------------------------------------------
// <copyright file="Step.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
//-------------------------------------------------------------------------------

namespace Full_GRASP_And_SOLID.Library
{
    public class Step
    {
        public Step(Product input, double quantity, Equipment equipment, int time)
        {
            this.Quantity = quantity;
            this.Input = input;
            this.Time = time;
            this.Equipment = equipment;
        }

        public Product Input { get; set; }

        public double Quantity { get; set; }

        public int Time { get; set; }

        public Equipment Equipment { get; set; }

        /// <summary>
        /// Agregamos este método para calcular el costo del Step, aplicamos Expert para asignar esta responsabilidad, ya que 
        /// la clase Step conoce todos los datos necesarios para calcular su costo
        /// </summary>
        /// <returns>Costo total del Step (costo insumo + costo equipamiento)</returns>
        public double GetCost()
        {
            double productsCost = this.Input.UnitCost * this.Quantity;
            double equipmentCost = this.Equipment.HourlyCost * (this.Time / 60);

            return productsCost + equipmentCost;
        }
    }
}