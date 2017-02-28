using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using CapaNegocio; // improtar capa

namespace CapaPresentacion
{
    public partial class FrmCategoria1 : Form
    {
        private bool IsNuevo = false; //indica si se va a insertar
        private bool IsEditar = false;

        public FrmCategoria1()
        {
            InitializeComponent();
            this.ttmensaje.SetToolTip(this.txtnombre, "Ingrese el nombre de la categoria");

        }
        //mostrar mensaje de confirmacion
        private void MensajeOK(string mensaje)
        {
            MessageBox.Show(mensaje, "Sistema de ventas", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
        //mostrar mensaje de error
        private void MensajeError(string mensaje)
        {
            MessageBox.Show(mensaje, "Sistema de ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }
        //limpiar todos los controles de formulario
        private void Limpiar()
        {
            this.txtnombre.Text = string.Empty;
            this.txtdescripcion.Text = string.Empty;
            this.txtidcodigo.Text = string.Empty;
        }
        private void Habilitar(bool valor)
        {
            this.txtnombre.ReadOnly = !valor;
            this.txtdescripcion.ReadOnly = !valor;
            this.txtidcodigo.ReadOnly = !valor;
        }
        //habilitar los botones
        private void Botones()
        {
            if(this.IsNuevo || this.IsEditar)
            {
                this.Habilitar(true);
                this.btnNuevo.Enabled = false;
                this.btnguardar.Enabled = true;
                this.btneditar.Enabled = false;
                this.btncancelar.Enabled = true;
            }
            else
            {
                this.Habilitar(false);
                this.btnNuevo.Enabled = true;
                this.btnguardar.Enabled = false;
                this.btneditar.Enabled = true;
                this.btncancelar.Enabled = false;
            }
        }
        //metodo para ocultar las columnas :D
        private void OcultarColumnas()
        {
            //this.dataListado.Columns[0].Visible = false;
           // this.dataListado.Columns[1].Visible = true;

        }
        //metodo mostrar
        private void Mostrar()
        {
            this.dataListado.DataSource = clsNCategoria.Mostrar();
            this.OcultarColumnas();
            lblmostrar.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);

        }
        //metodo bsucarNombre
        private void BuscarNombrer()
        {
            this.dataListado.DataSource = clsNCategoria.BuscarNomre(this.txtBuscar.Text);
            this.OcultarColumnas();
            lblmostrar.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);

        }

        private void FrmCategoria1_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;

            this.Mostrar();
            this.Habilitar(false);
            this.Botones();

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.BuscarNombrer();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            this.BuscarNombrer();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            this.IsNuevo = true;
            this.IsEditar = false;
            this.Botones();
            this.Limpiar();
            this.Habilitar(true);
            this.txtnombre.Focus();


        }

        private void btnguardar_Click(object sender, EventArgs e)
        {
            try
            {
                string rpta = "";
                if(this.txtnombre.Text==string.Empty)
                {
                    MensajeError("falta inresar algunos datos, seran remarcados");
                    erroricono.SetError(txtnombre, "Ingrese un nombre");

                    
                }
                else
                {
                    if (this.IsNuevo)
                    {
                        rpta = clsNCategoria.Insertar(this.txtnombre.Text.Trim().ToUpper(),this.txtdescripcion.Text.Trim());

                    }
                    else
                    {
                       // rpta = clsNCategoria.Editar(Convert.ToInt32(this.txtidcodigo.Text), this.txtnombre.Text.Trim().ToUpper(), this.txtdescripcion.Text.Trim());
                    }
                    if(rpta.Equals("ok"))
                    {
                        if(this.IsNuevo)
                        {
                            this.MensajeOK("Se inserto de forma correcta el registro");
                        }
                        else
                        {
                            this.MensajeOK("Se actualiza de forma correcta el registro");
                        }
                    }
                    else
                    {
                        this.MensajeError(rpta);
                    }
                    this.IsNuevo = false;
                    this.IsEditar = false;
                    this.Botones();
                    this.Limpiar();
                    this.Mostrar();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void dataListado_DoubleClick(object sender, EventArgs e)
        {
            this.txtidcodigo.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["idcategoria"].Value);
            this.txtnombre.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["nombre"].Value);
            this.txtdescripcion.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["descripcion"].Value);
            this.tabControl1.SelectedIndex = 1;
        }

        private void btneditar_Click(object sender, EventArgs e)
        {
            if(this.txtidcodigo.Text.Equals(""))
            {
                this.IsEditar = true;
                this.Botones();
                this.Habilitar(true);
            }
            else
            {
                this.MensajeError("debe seleccionar primero el registro a modificar");

            }
        }

        private void btncancelar_Click(object sender, EventArgs e)
        {
            this.IsNuevo = false;
            this.IsEditar = false;
            this.Botones();
            this.Limpiar();
            this.Habilitar(false);
        }

        private void chkEliminar_CheckedChanged(object sender, EventArgs e)
        {
            if (chkEliminar.Checked)
            {
                this.dataListado.Columns[0].Visible = true;
            }
            else
            {
                this.dataListado.Columns[0].Visible = false;
            }

        }

        private void dataListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ttmensaje_Popup(object sender, PopupEventArgs e)
        {

        }
    }
}
