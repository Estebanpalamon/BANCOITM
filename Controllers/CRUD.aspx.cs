using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebBancoITM.Models;

namespace WebBancoITM.Pages
{
    public partial class CRUD : System.Web.UI.Page
    {
        readonly SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);
        public static string sID = "-1";
        public static string sOpc = "";
        private string connectionString;
        private int idUsuario;

        protected void Page_Load(object sender, EventArgs e)
        {
            connectionString = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;

            if (!Page.IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
                    sID = Request.QueryString["id"].ToString();
                    CargarDatos();
                }

                if (Request.QueryString["op"] != null)
                {
                    sOpc = Request.QueryString["op"].ToString();

                    switch (sOpc)
                    {
                        case "C":
                            lbltitulo.Text = "Ingresar nuevo usuario";
                            BtnCreate.Visible = true;
                            break;
                        case "R":
                            lbltitulo.Text = "Consulta de usuario";
                            break;
                        case "U":
                            lbltitulo.Text = "Modificar usuario";
                            BtnUpdate.Visible = true;
                            break;
                        case "D":
                            lbltitulo.Text = "Eliminar usuario";
                            BtnDelete.Visible = true;
                            break;
                    }
                }
            }
        }

        protected void BtnCalcular_Click(object sender, EventArgs e)
        {
            double valorVivienda;

            if (double.TryParse(tbvalorvivienda.Text, out valorVivienda))
            {
                DatosFinancierosModel datosFinancieros = new DatosFinancierosModel
                {
                    ValorVivienda = valorVivienda,
                    Tasa = 0.0115M,  // Tasa de interés mensual
                    Plazo = 240     // Plazo en meses (20 años)
                };

                datosFinancieros.CalcularDatosFinancieros();

                tbPorcentajeCuotaInicial.Text = datosFinancieros.PorcentajeCuotaInicial.ToString("P2");
                tbValorCuotaInicial.Text = datosFinancieros.ValorCuotaInicial.ToString("C2");
                tbValorCredito.Text = datosFinancieros.Credito.ToString("C2");
                tbCuotaSinBeneficio.Text = datosFinancieros.CuotaSinBeneficio.ToString("C2");
                tbValorBeneficio.Text = datosFinancieros.ValorBeneficio.ToString("C2");
                tbCuotaConBeneficio.Text = datosFinancieros.CuotaConBeneficio.ToString("C2");

                lblMensajeError.Text = string.Empty;
            }
            else
            {
                lblMensajeError.Text = "El valor de la vivienda no es válido. Por favor, ingrese un valor numérico.";
            }
        }
        protected void CargarDatos()
        {
            if (!string.IsNullOrEmpty(sID) && int.TryParse(sID, out int idUsuario))
            {
                try
                {
                    using (SqlConnection con = new SqlConnection(connectionString))
                    {
                        using (SqlCommand cmd = new SqlCommand("sp_read", con))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.Add("@Id", SqlDbType.Int).Value = idUsuario;

                            con.Open();

                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    txtIdUsuario.Text = reader["Id_Usuario"].ToString();
                                    tbnombre.Text = reader["Nombre"].ToString();
                                    tbapellidos.Text = reader["Apellido"].ToString();
                                    tbvalorvivienda.Text = reader["Valor_Vivienda"].ToString();
                                }
                                else
                                {
                                    lblMensajeError.Text = "No se encontraron datos para el ID de Usuario proporcionado.";
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    lblMensajeError.Text = "Error al cargar los datos: " + ex.Message;
                }
            }
            else
            {
                lblMensajeError.Text = "El ID de Usuario no es un número válido.";
            }
        }

        protected void BtnCreate_Click(object sender, EventArgs e)
        {
            if (double.TryParse(tbvalorvivienda.Text, out double valorVivienda) && int.TryParse(txtIdUsuario.Text, out int idUsuario))
            {
                try
                {
                    using (SqlConnection con = new SqlConnection(connectionString))
                    {
                        using (SqlCommand cmd = new SqlCommand("sp_create", con))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;

                            UsuarioModel usuario = new UsuarioModel
                            {
                                Id = idUsuario,
                                Nombre = tbnombre.Text,
                                Apellido = tbapellidos.Text,
                                ValorVivienda = valorVivienda,
                                Tasa = 1.15M,
                                Plazo = 240,
                                PorcentajeCuotaInicial = decimal.Parse(tbPorcentajeCuotaInicial.Text.TrimEnd('%')),
                                ValorCuotaInicial = decimal.Parse(tbValorCuotaInicial.Text, NumberStyles.Currency),
                                Credito = decimal.Parse(tbValorCredito.Text, NumberStyles.Currency),
                                ValorBeneficio = decimal.Parse(tbValorBeneficio.Text, NumberStyles.Currency),
                                CuotaSinBeneficio = decimal.Parse(tbCuotaSinBeneficio.Text, NumberStyles.Currency),
                                CuotaConBeneficio = decimal.Parse(tbCuotaConBeneficio.Text, NumberStyles.Currency)
                            };

                            cmd.Parameters.Add("@Id_Usuario", SqlDbType.Int).Value = usuario.Id; // Supongo que el campo ID es de tipo entero en la base de datos
                            cmd.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = usuario.Nombre;
                            cmd.Parameters.Add("@Apellido", SqlDbType.VarChar).Value = usuario.Apellido;
                            cmd.Parameters.Add("@Valor_Vivienda", SqlDbType.Int).Value = usuario.ValorVivienda;
                            cmd.Parameters.Add("@Tasa", SqlDbType.Decimal).Value = usuario.Tasa;
                            cmd.Parameters.Add("@Plazo", SqlDbType.Int).Value = usuario.Plazo;
                            cmd.Parameters.Add("@PorcentajeCuotaInicial", SqlDbType.Decimal).Value = usuario.PorcentajeCuotaInicial;
                            cmd.Parameters.Add("@ValorCuotaInicial", SqlDbType.Decimal).Value = usuario.ValorCuotaInicial;
                            cmd.Parameters.Add("@Credito", SqlDbType.Decimal).Value = usuario.Credito;
                            cmd.Parameters.Add("@ValorBeneficio", SqlDbType.Decimal).Value = usuario.ValorBeneficio;
                            cmd.Parameters.Add("@CuotaSinBeneficio", SqlDbType.Decimal).Value = usuario.CuotaSinBeneficio;
                            cmd.Parameters.Add("@CuotaConBeneficio", SqlDbType.Decimal).Value = usuario.CuotaConBeneficio;

                            con.Open();
                            cmd.ExecuteNonQuery();
                            Response.Redirect("Index.aspx");
                        }
                    }
                }
                catch (Exception ex)
                {
                    lblMensajeError.Text = "Ocurrió un error al crear el usuario: " + ex.Message;
                }
            }
            else
            {
                lblMensajeError.Text = "Ingrese un valor de vivienda válido y un ID válido.";
            }
        }


        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(sID) && int.TryParse(sID, out int idUsuario))
            {
                try
                {
                    using (SqlConnection con = new SqlConnection(connectionString))
                    {
                        using (SqlCommand cmd = new SqlCommand("sp_update", con))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;

                            UsuarioModel usuario = new UsuarioModel
                            {
                                Id = idUsuario,
                                Nombre = tbnombre.Text,
                                Apellido = tbapellidos.Text,
                                ValorVivienda = Convert.ToDouble(tbvalorvivienda.Text),
                                Tasa = 1.15M,
                                Plazo = 240,
                                PorcentajeCuotaInicial = decimal.Parse(tbPorcentajeCuotaInicial.Text.TrimEnd('%')),
                                ValorCuotaInicial = decimal.Parse(tbValorCuotaInicial.Text, NumberStyles.Currency),
                                Credito = decimal.Parse(tbValorCredito.Text, NumberStyles.Currency),
                                ValorBeneficio = decimal.Parse(tbValorBeneficio.Text, NumberStyles.Currency),
                                CuotaSinBeneficio = decimal.Parse(tbCuotaSinBeneficio.Text, NumberStyles.Currency),
                                CuotaConBeneficio = decimal.Parse(tbCuotaConBeneficio.Text, NumberStyles.Currency)
                            };

                            cmd.Parameters.Add("@Id", SqlDbType.Int).Value = usuario.Id;
                            cmd.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = usuario.Nombre;
                            cmd.Parameters.Add("@Apellido", SqlDbType.VarChar).Value = usuario.Apellido;
                            cmd.Parameters.Add("@Valor_Vivienda", SqlDbType.Int).Value = usuario.ValorVivienda;
                            cmd.Parameters.Add("@Tasa", SqlDbType.Decimal).Value = usuario.Tasa;
                            cmd.Parameters.Add("@Plazo", SqlDbType.Int).Value = usuario.Plazo;
                            cmd.Parameters.Add("@PorcentajeCuotaInicial", SqlDbType.Decimal).Value = usuario.PorcentajeCuotaInicial;
                            cmd.Parameters.Add("@ValorCuotaInicial", SqlDbType.Decimal).Value = usuario.ValorCuotaInicial;
                            cmd.Parameters.Add("@Credito", SqlDbType.Decimal).Value = usuario.Credito;
                            cmd.Parameters.Add("@ValorBeneficio", SqlDbType.Decimal).Value = usuario.ValorBeneficio;
                            cmd.Parameters.Add("@CuotaSinBeneficio", SqlDbType.Decimal).Value = usuario.CuotaSinBeneficio;
                            cmd.Parameters.Add("@CuotaConBeneficio", SqlDbType.Decimal).Value = usuario.CuotaConBeneficio;

                            con.Open();
                            cmd.ExecuteNonQuery();
                            Response.Redirect("Index.aspx");
                        }
                    }
                }
                catch (Exception ex)
                {
                    lblMensajeError.Text = "Ocurrió un error al actualizar el usuario: " + ex.Message;
                }
            }
            else
            {
                lblMensajeError.Text = "El ID de Usuario no es un número válido.";
            }
        }

        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(sID) && int.TryParse(sID, out int idUsuario))
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("sp_delete", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add("@Id", SqlDbType.Int).Value = idUsuario;

                        try
                        {
                            con.Open();
                            cmd.ExecuteNonQuery();
                            Response.Redirect("Index.aspx");
                        }
                        catch (Exception ex)
                        {
                            lblMensajeError.Text = "Ocurrió un error al eliminar el usuario: " + ex.Message;
                        }
                    }
                }
            }
            else
            {
                lblMensajeError.Text = "El ID de Usuario no es un número válido.";
            }
        }

        protected void BtnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("Index.aspx");
        }
    }
}
