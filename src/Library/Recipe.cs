//-------------------------------------------------------------------------
// <copyright file="Recipe.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
//-------------------------------------------------------------------------

using System;
using System.Collections;

namespace Full_GRASP_And_SOLID.Library
{
    public class Recipe
    {
        private ArrayList steps = new ArrayList();

        public Product FinalProduct { get; set; }

        public void AddStep(Step step)
        {
            this.steps.Add(step);
        }

        public void RemoveStep(Step step)
        {
            this.steps.Remove(step);
        }

        public void PrintRecipe()
        {
            Console.WriteLine($"Receta de {this.FinalProduct.Description}:");
            foreach (Step step in this.steps)
            {
                Console.WriteLine($"{step.Quantity} de '{step.Input.Description}' " +
                    $"usando '{step.Equipment.Description}' durante {step.Time} " +
                    $"costo total de producción: {this.GetProductionCost()}");
            }
        }


        /// <summary>
        /// Agregamos acá el método para obtener el costo total de producción. También lo hicimos basándonos en Expert
        /// ya que esta clase es experta en los datos que se necesitan para el cálculo, que basicamente son
        /// los steps. 
        /// 
        /// Por otro lado, para no sobre cargar esta clase, fue que hicimos que cada step sepa calcular su propio costo,
        /// ya que si nos basamos en SRP, no debería ser responsabilidad de la clase Recipe calcular el costo de
        /// sus steps, sino que de cada step debería poder calcular su costo y la clase Recipe simplemente le pide el resultado
        /// del cálculo del costo a cada uno para calcular el total.
        /// </summary>
        /// <returns></returns>
        public double GetProductionCost()
        {
            double totalCost = 0;

            foreach (Step step in this.steps)
            {
                totalCost += step.GetCost();
            }

            return totalCost;
        }

    }
}