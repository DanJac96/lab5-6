using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaDato.Entidades;
using CapaDatos;

namespace Laboratorio5_6
{
    public partial class Grid : System.Web.UI.Page
    {
        GestionBD objGestion;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cargaCarro();
            }
        }
        void cargaCarro()
        {
            DataTable datosCarros = new DataTable();
            objGestion = new GestionBD();
            datosCarros = objGestion.cargaCarro();

            if (datosCarros.Rows.Count > 0)
            {
                GridCarro.DataSource = datosCarros;
                GridCarro.DataBind();
            }
            else
            {
                datosCarros.Rows.Add(datosCarros.NewRow());
                GridCarro.DataSource = datosCarros;
                GridCarro.DataBind();
                GridCarro.Rows[0].Cells.Clear();
                GridCarro.Rows[0].Cells.Add(new TableCell());
                GridCarro.Rows[0].Cells[0].ColumnSpan = datosCarros.Columns.Count;
                GridCarro.Rows[0].Cells[0].Text = "No se encontro ningun dato para mostrar...";
                GridCarro.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;
            }
        }
        void mostrarMensaje(string txtMensaje, bool Tipo)
        {
            if (Tipo)
            {
                lblExito.Text = txtMensaje;
                lblError.Text = "";
            }
            else
            {
                lblExito.Text = "";
                lblError.Text = txtMensaje;
            }
        }
        protected void GridCarro_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("AddNew"))
            {
                objGestion = new GestionBD();
                Carro objCarro = new Carro();
                objCarro.idCarro = Convert.ToInt32((GridCarro.FooterRow.FindControl("txtCarroPie") as TextBox).Text.Trim());
                objCarro.Marca = (GridCarro.FooterRow.FindControl("txtMarcaPie") as TextBox).Text.Trim();
                objCarro.Modelo = (GridCarro.FooterRow.FindControl("txtModelCarroPie") as TextBox).Text.Trim();
                objCarro.Pais = (GridCarro.FooterRow.FindControl("txtPaisCarroPie") as TextBox).Text.Trim();
                objCarro.Costo = Convert.ToInt32((GridCarro.FooterRow.FindControl("txtPrecioCarroPie") as TextBox).Text.Trim());
                int resultado = objGestion.registrarCarro(objCarro);

                if (resultado == 1)
                {
                    cargaCarro();
                    mostrarMensaje("Registro Exitoso", true);
                }
                else
                {
                    mostrarMensaje("Existe un error en el registro del Vehiculo", false);

                }
            }
        }

        protected void GridCarro_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridCarro.EditIndex = e.NewEditIndex;
            cargaCarro();
        }

        protected void GridCarro_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridCarro.EditIndex = -1;
            cargaCarro();
        }

        protected void GridCarro_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            objGestion = new GestionBD();
            Carro objCarro = new Carro();
            objCarro.idCarro = Convert.ToInt32(GridCarro.DataKeys[e.RowIndex].Value.ToString());
            objGestion.eliminarCarro(objCarro);
            GridCarro.EditIndex = -1;
            cargaCarro();

            mostrarMensaje("Borrado Exitoso", true);

        }

        protected void GridCarro_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            objGestion = new GestionBD();
            Carro objCarro = new Carro();
            objCarro.Marca = (GridCarro.Rows[e.RowIndex].FindControl("txtMarca") as TextBox).Text.Trim();
            objCarro.Modelo = (GridCarro.Rows[e.RowIndex].FindControl("txtModelCarro") as TextBox).Text.Trim();
            objCarro.Pais = (GridCarro.Rows[e.RowIndex].FindControl("txtPaisCarro") as TextBox).Text.Trim();
            objCarro.Costo = Convert.ToInt32((GridCarro.Rows[e.RowIndex].FindControl("txtPrecioCarro") as TextBox).Text.Trim());
            objCarro.idCarro = Convert.ToInt32(GridCarro.DataKeys[e.RowIndex].Value.ToString());
            int resultado = objGestion.actualizarCarro(objCarro);
            GridCarro.EditIndex = -1;


            if (resultado == 1)
            {
                cargaCarro();
                mostrarMensaje("Actualizacion Exitosa", true);
            }
            else
            {
                mostrarMensaje("Existe un error en el registro del Vehiculo", false);

            }
        }
    }
}