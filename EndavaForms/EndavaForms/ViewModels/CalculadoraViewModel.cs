using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using System.Collections.Generic;

namespace EndavaForms.ViewModels
{
    public class CalculadoraViewModel : ViewModelBase
    {
        #region Atributos

        private string _ultimaOperacion;

        private string _seleccionUsuario;

        private double _opcionUno;

        private double _opcionDos;

        private string _operador;

        private double _resultado;

        private List<string> _listaNumeros;

        private List<string> _listaOperadores;

        #endregion

        #region Propiedades

        public string UltimaOperacion
        {
            get => _ultimaOperacion;
            set => SetProperty(ref _ultimaOperacion, value);
        }

        public string SeleccionUsuario
        {
            get => _seleccionUsuario;
            set => SetProperty(ref _seleccionUsuario, value);
        }

        #endregion

        #region Commands

        public DelegateCommand<string> OpcionCommand { get; set; }

        #endregion

        #region Constructor

        public CalculadoraViewModel(INavigationService navigationService, IPageDialogService dialogService) : base(navigationService, dialogService)
        {
            InstanciarObjetos();
        }

        #endregion

        #region Metodos Privados

        private void InstanciarObjetos()
        {
            Title = "Calculadora";

            CargarListas();

            OpcionCommand = new DelegateCommand<string>(Opcion);
        }

        private void CargarListas()
        {
            _listaNumeros = new List<string>
            {
                "0",
                "1",
                "2",
                "3",
                "4",
                "5",
                "6",
                "7",
                "8",
                "9",
                "."
            };

            _listaOperadores = new List<string>
            {
                "+",
                "-",
                "*",
                "/",
                "+-",
                "="
            };
        }

        private void Opcion(string opcionUsuario)
        {
            if (_listaNumeros.Contains(opcionUsuario))
            {
                SeleccionUsuario = string.Concat(SeleccionUsuario, opcionUsuario);
                return;
            }
            if (_listaOperadores.Contains(opcionUsuario))
            {
                ManejoOperadores(opcionUsuario);
                return;
            }
            if (opcionUsuario.Equals("CE"))
            {
                if (string.IsNullOrEmpty(_operador))
                {
                    _opcionUno = double.NaN;
                }
                else
                {
                    _opcionDos = double.NaN;
                }
                SeleccionUsuario = string.Empty;
                return;
            }
            if (opcionUsuario.Equals("C"))
            {
                _opcionUno = double.NaN;
                _opcionDos = double.NaN;
                SeleccionUsuario = string.Empty;
                _operador = string.Empty;
                return;
            }
            if (opcionUsuario.Equals("DEL"))
            {
                SeleccionUsuario = SeleccionUsuario.Substring(0, SeleccionUsuario.Length - 1);
                return;
            }
        }

        private async void ManejoOperadores(string operadorSeleccioando)
        {
            if (operadorSeleccioando.Equals("+-"))
            {
                if (SeleccionUsuario.Substring(0, 1).Equals("-"))
                {
                    SeleccionUsuario = SeleccionUsuario.Substring(1, SeleccionUsuario.Length - 1);
                }
                else
                {
                    SeleccionUsuario = "-" + SeleccionUsuario;
                }
                return;
            }

            if (string.IsNullOrEmpty(_operador))
            {
                _opcionUno = double.Parse(SeleccionUsuario);
                _operador = operadorSeleccioando;
                UltimaOperacion = string.Concat(SeleccionUsuario, operadorSeleccioando);
                SeleccionUsuario = string.Empty;
            }
            else
            {
                if (operadorSeleccioando.Equals("="))
                {
                    _opcionDos = double.Parse(SeleccionUsuario);
                    string resultado = string.Empty;
                    switch (_operador)
                    {
                        case "+":
                            resultado = (_opcionUno + _opcionDos).ToString();
                            break;
                        case "-":
                            resultado = (_opcionUno - _opcionDos).ToString();
                            break;
                        case "*":
                            resultado = (_opcionUno * _opcionDos).ToString();
                            break;
                        case "/":
                            if (_opcionDos.Equals(0))
                            {
                                await DialogService.DisplayAlertAsync("Validación", "La división por 0 no esta permitida", "OK");
                                _opcionUno = double.NaN;
                                _opcionDos = double.NaN;
                                UltimaOperacion = string.Empty;
                                SeleccionUsuario = string.Empty;
                                _operador = string.Empty;
                                return;
                            }
                            else
                            {
                                resultado = (_opcionUno / _opcionDos).ToString();
                            }
                            break;
                    }

                    UltimaOperacion = string.Concat(UltimaOperacion, _opcionDos, operadorSeleccioando, resultado);
                    SeleccionUsuario = resultado;
                    _operador = string.Empty;
                }
                else
                {
                    _operador = operadorSeleccioando;
                }
            }
        }

        #endregion

    }
}
