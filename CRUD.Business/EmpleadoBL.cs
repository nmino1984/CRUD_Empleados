using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRUD.DataLayer;
using CRUD.EntityLayer;

namespace CRUD.BusinessLayer
{
    public class EmpleadoBL
    {
        EmpleadoDL empleadoDL = new EmpleadoDL();

        public List<Empleado> List()
        {
            try
            {
                return empleadoDL.List();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Empleado Get(int id)
        {
            try
            {
                return empleadoDL.Get(id);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }



        public bool Create(Empleado entity)
        {
            try
            {
                if (entity.NombreCompleto.Trim() == "")
                    throw new OperationCanceledException("El nombre no puede ser vacío");

                return empleadoDL.Create(entity);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool Edit(Empleado entity)
        {
            try
            {
                var found = empleadoDL.Get(entity.IdEmpleado);

                if (found.IdEmpleado == 0)
                    throw new OperationCanceledException("El empleado no ha sifo encontrado");

                return empleadoDL.Edit(entity);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                var found = empleadoDL.Get(id);

                if (found.IdEmpleado == 0)
                    throw new OperationCanceledException("El empleado no ha sifo encontrado");

                return empleadoDL.Delete(id);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }
}
