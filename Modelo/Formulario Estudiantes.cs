using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using MySql.Data.MySqlClient;
using System.Web.UI.WebControls;

namespace web_umg_bd
{
    public class Estudiantes
    {
        ConexionBD conectar;
        private DataTable drop_estudiante(){
            DataTable tabla = new DataTable();
            conectar = new ConexionBD();
            conectar.AbrirConexion();
            string strConsulta = string.Format("select id_carne as id,carne from estudiantes;");
            MySqlDataAdapter consulta = new MySqlDataAdapter(strConsulta, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerarConexion();
            return tabla;
        }
        public void drop_estudiante(DropDownList drop){
            drop.ClearSelection();
            drop.Items.Clear();
            drop.AppendDataBoundItems = true;
            drop.Items.Add("<< Elige carne >>");
            drop.Items[0].Value = "0";
            drop.DataSource = drop_estudiante();
            drop.DataTextField = "carne";
            drop.DataValueField = "id";
            drop.DataBind();

        }
        private DataTable grid_estudiantes() {
            DataTable tabla = new DataTable();
            conectar = new ConexionBD();
            conectar.AbrirConexion();
            String consulta = string.Format("select e.id_estudiante as id,e.carne,e.nombres,e.apellidos,e.direccion,e.telefono,e.fecha_nacimiento from estudiantes");
            MySqlDataAdapter query = new MySqlDataAdapter(consulta, conectar.conectar);
            query.Fill(tabla);
            conectar.CerarConexion();
            return tabla;
        }
        public void grid_estudiantes(GridView grid){
            grid.DataSource = grid_empleados();
            grid.DataBind();

        }
        public int agregar(string codigo,string nombres,string apellidos,string direccion,string telefono,string fecha){
            int no_ingreso = 0;
            conectar = new ConexionBD();
            conectar.AbrirConexion();
            string strConsulta = string.Format("insert into estudiantes(codigo,nombres,apellidos,direccion,telefono,fecha_nacimiento) values('{0}','{1}','{2}','{3}','{4}','{5}',{6});",codigo,nombres,apellidos,direccion,telefono,fecha);
            MySqlCommand insertar = new MySqlCommand(strConsulta, conectar.conectar);
            
            insertar.Connection = conectar.conectar;
            no_ingreso = insertar.ExecuteNonQuery();
            conectar.CerarConexion();
            return no_ingreso;

        }
        public int modificar(int id,string codigo, string nombres, string apellidos, string direccion, string telefono, string fecha){
            int no_ingreso = 0;
            conectar = new ConexionBD();
            conectar.AbrirConexion();
            string strConsulta = string.Format("update estudiantes set codigo = '{0}',nombres = '{1}',apellidos = '{2}',direccion='{3}',telefono='{4}',fecha_nacimiento='{5}';", carne, nombres, apellidos, direccion, telefono, fecha);
            MySqlCommand modificar = new MySqlCommand(strConsulta, conectar.conectar);

            modificar.Connection = conectar.conectar;
            no_ingreso = modificar.ExecuteNonQuery();
            conectar.CerarConexion();
            return no_ingreso;
        }
        public int eliminar(int id){
            int no_ingreso = 0;
        conectar = new ConexionBD();
        conectar.AbrirConexion();
            string strConsulta = string.Format("delete from estudiantes  where id_estudiante = {0};", id);
        MySqlCommand eliminar = new MySqlCommand(strConsulta, conectar.conectar);

            eliminar.Connection = conectar.conectar;
            no_ingreso = eliminar.ExecuteNonQuery();
            conectar.CerarConexion();
            return no_ingreso;
        }

}
}