﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nueva_Biblioteca
{
    public partial class frmAutores : Form
    {
        public bool bandera = false;
        static private frmAutores instancia = null;
        static csAutores claseAutor = new csAutores();
        private csLLenarDataGridView buscar = new csLLenarDataGridView();
        private csReutilizacion verificar = new csReutilizacion();
        public static frmAutores Formulario()
        {
            if (instancia == null) { instancia = new frmAutores(); }
            return instancia;
        }
        public frmAutores()
        {
            InitializeComponent();
        }
        private void frmAutores_Load(object sender, EventArgs e)
        {
            claseAutor.Mostrar(dgvAutores);
        }
        private void dgvAutores_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            frmAgregarOEditarAutor frm = new frmAgregarOEditarAutor();
            this.AddOwnedForm(frm);
            if (e.ColumnIndex == dgvAutores.Columns[dgvAutores.ColumnCount - 1].Index && e.RowIndex >= 0)
            {
                claseAutor.Codigo = dgvAutores.Rows[e.RowIndex].Cells[0].Value.ToString();
                frm.txtDescripcion.Text = dgvAutores.Rows[e.RowIndex].Cells[1].Value.ToString();
                if (dgvAutores.Rows[e.RowIndex].Cells[2].Value.ToString() == "Activo") { frm.cbEstado.SelectedItem = frm.cbEstado.Items[0]; }
                else { frm.cbEstado.SelectedItem = frm.cbEstado.Items[1]; }
                frm.txtDescripcion.Enabled = false;
                frm.cbEstado.Enabled = false;
                frm.ShowDialog();
            }
        }
        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            if (txtBuscar.Text.Length >= 3)
            {
                string consulta = "SELECT IdAutor, Autor, Estado " +
                                  "FROM AUTOR " +
                                  "WHERE IdAutor LIKE '%" + txtBuscar.Text + "%' " +
                                  "OR Autor LIKE '%" + txtBuscar.Text + "%' ";
                dgvAutores.Rows.Clear();
                buscar.Mostrar(dgvAutores, consulta, 1);
            }
            else
            {
                dgvAutores.Rows.Clear();
                claseAutor.Mostrar(dgvAutores);
            }
        }
        private void btnCrear_Click(object sender, EventArgs e)
        {
            bandera = true;
            frmAgregarOEditarAutor frm = new frmAgregarOEditarAutor();
            this.AddOwnedForm(frm);
            frm.btnEditar.Visible = false;
            frm.cbEstado.SelectedItem = "Activo";
            frm.ShowDialog();
        }
    }
}
