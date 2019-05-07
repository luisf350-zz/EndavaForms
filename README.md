# EndavaForms
Calculadora

Prism
 

Nuevo Proyecto de Xamarin Forms con la plantilla de Prism
 
 
Actualicemos el paquete de Nuget de Xamarin.Forms
 

Eliminemos estos archivos para crearlos de nuevo
 

Sobre la carpeta Views, vamos a crear un nuevo elemento para la MasterPage
 
 

De la misma manera, vamos a adicionar 3 nuevos elementos (Calculadora, ListaRest y LocalDb) pero esta vez serán ContentPage
 

Como podemos ver en el archivo App.xaml.cs, se registraron los tipos de navegación para las pantallas que creamos, asociadas a su respectivo ViewModel. Vamos a hacer un pequeño cambio para que la pagina principal sea nuestra MasterPage y cargue la Calculadora al comienzo.
 

Ahora vamos a adicionar las opciones de nuestras paginas a la Master Page.
 

Y en el ViewModel de la MasterPage, vamos a crear el command que va realizar la navegación entre páginas. Tambien tenemos que hacer unos cambios:
1.	El ViewModel esta heredando de BindableBase. Vamos a cambiar esto y ahora vamos a heredar de ViewModelBase.
2.	Ahora el constructor recibe como parámetro una interface de NavigationService, ese mismo parámetro se envia a la clase base.
3.	Creamos una propiedad de tipo DelegateCommand para el manejar el comando cuando se seleccione una opción en la vista.
4.	Haciendo uso de la Interface de navegación (NavigationService), vamos a navegar a la opción seleccionada (este método debe ser asíncrono y su invocación debe tener la palabra reservada await)
 

Para Efectos de una prueba inicial, vamos a poner texto en las paginas de Calculadora, Lista Rest y Local DB.

 
 
 

Adicionamos el siguiente código a la pantalla de Calculadora y a su ViewModel para tener la calculadora Funcionando

<ContentPage xmlns="http://xamarin.com/schemas/2014/forms"
             xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
             xmlns:prism="clr-namespace:Prism.Mvvm;assembly=Prism.Forms"
             prism:ViewModelLocator.AutowireViewModel="True"
             x:Class="EndavaForms.Views.Calculadora"
             Title="{Binding Title}">

    <Grid>
        <Grid.RowDefinitions>
            <RowDefinition Height="2*"></RowDefinition>
            <RowDefinition Height="1*"></RowDefinition>
            <RowDefinition Height="1*"></RowDefinition>
            <RowDefinition Height="1*"></RowDefinition>
            <RowDefinition Height="1*"></RowDefinition>
            <RowDefinition Height="1*"></RowDefinition>
            <RowDefinition Height="1*"></RowDefinition>
        </Grid.RowDefinitions>
        <Grid.ColumnDefinitions>
            <ColumnDefinition Width="1*"></ColumnDefinition>
            <ColumnDefinition Width="1*"></ColumnDefinition>
            <ColumnDefinition Width="1*"></ColumnDefinition>
            <ColumnDefinition Width="1*"></ColumnDefinition>
        </Grid.ColumnDefinitions>

        <Label Grid.Row="0" Grid.Column="0" Grid.ColumnSpan="4"
                Text="{Binding UltimaOperacion, Mode=OneWay}"></Label>
        <Label Grid.Row="1" Grid.Column="0" Grid.ColumnSpan="4"
                Text="{Binding SeleccionUsuario, Mode=OneWay}"></Label>

        <Button Grid.Row="2" Grid.Column="0"
                    Text="CE" 
                    Command="{Binding OpcionCommand}"
                    CommandParameter="CE"></Button>
        <Button Grid.Row="2" Grid.Column="1"
                    Text="C" 
                    Command="{Binding OpcionCommand}"
                    CommandParameter="C"></Button>
        <Button Grid.Row="2" Grid.Column="2"
                    Text="DEL" 
                    Command="{Binding OpcionCommand}"
                    CommandParameter="DEL"></Button>
        <Button Grid.Row="2" Grid.Column="3"
                    Text="/" 
                    Command="{Binding OpcionCommand}"
                    CommandParameter="/"></Button>

        <Button Grid.Row="3" Grid.Column="0"
                    Text="7" 
                    Command="{Binding OpcionCommand}"
                    CommandParameter="7"></Button>
        <Button Grid.Row="3" Grid.Column="1"
                    Text="8" 
                    Command="{Binding OpcionCommand}"
                    CommandParameter="8"></Button>
        <Button Grid.Row="3" Grid.Column="2"
                    Text="9" 
                    Command="{Binding OpcionCommand}"
                    CommandParameter="9"></Button>
        <Button Grid.Row="3" Grid.Column="3"
                    Text="*" 
                    Command="{Binding OpcionCommand}"
                    CommandParameter="*"></Button>

        <Button Grid.Row="4" Grid.Column="0"
                    Text="4" 
                    Command="{Binding OpcionCommand}"
                    CommandParameter="4"></Button>
        <Button Grid.Row="4" Grid.Column="1"
                    Text="5" 
                    Command="{Binding OpcionCommand}"
                    CommandParameter="5"></Button>
        <Button Grid.Row="4" Grid.Column="2"
                    Text="6" 
                    Command="{Binding OpcionCommand}"
                    CommandParameter="6"></Button>
        <Button Grid.Row="4" Grid.Column="3"
                    Text="-" 
                    Command="{Binding OpcionCommand}"
                    CommandParameter="-"></Button>

        <Button Grid.Row="5" Grid.Column="0"
                    Text="1" 
                    Command="{Binding OpcionCommand}"
                    CommandParameter="1"></Button>
        <Button Grid.Row="5" Grid.Column="1"
                    Text="2" 
                    Command="{Binding OpcionCommand}"
                    CommandParameter="2"></Button>
        <Button Grid.Row="5" Grid.Column="2"
                    Text="3" 
                    Command="{Binding OpcionCommand}"
                    CommandParameter="3"></Button>
        <Button Grid.Row="5" Grid.Column="3"
                    Text="+" 
                    Command="{Binding OpcionCommand}"
                    CommandParameter="+"></Button>

        <Button Grid.Row="6" Grid.Column="0"
                    Text="+-" 
                    Command="{Binding OpcionCommand}"
                    CommandParameter="+-"></Button>
        <Button Grid.Row="6" Grid.Column="1"
                    Text="0" 
                    Command="{Binding OpcionCommand}"
                    CommandParameter="0"></Button>
        <Button Grid.Row="6" Grid.Column="2"
                    Text="." 
                    Command="{Binding OpcionCommand}"
                    CommandParameter="."></Button>
        <Button Grid.Row="6" Grid.Column="3"
                    Text="=" 
                    Command="{Binding OpcionCommand}"
                    CommandParameter="="></Button>

    </Grid>

</ContentPage>

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

        public CalculadoraViewModel(INavigationService navigationService) : base(navigationService)
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

        private void ManejoOperadores(string operadorSeleccioando)
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
                            resultado = (_opcionUno / _opcionDos).ToString();
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

Se adiciona la interface PageDialogService a la clase ViewModelBase para hacer uso de los mensajes emergentes en nuestros ViewModels.

public class ViewModelBase : BindableBase, INavigationAware, IDestructible
    {
        #region Atributos

        private string _title;

        #endregion

        #region Propiedades

        protected INavigationService NavigationService { get; }

        protected IPageDialogService DialogService { get; }

        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }

        #endregion

        #region Constructor

        public ViewModelBase(INavigationService navigationService, IPageDialogService dialogService)
        {
            NavigationService = navigationService;
            DialogService = dialogService;
        }

        #endregion

        #region Metodos Virtuales

        public virtual void OnNavigatedFrom(INavigationParameters parameters)
        {

        }

        public virtual void OnNavigatedTo(INavigationParameters parameters)
        {

        }

        public virtual void OnNavigatingTo(INavigationParameters parameters)
        {

        }

        public virtual void Destroy()
        {

        }

        #endregion

    }

Adicionamos la validación de división por 0 al ViewModel de la Calculadora. Para esto, seguimos los siguientes pasos:
1.	Modificamos el constructor para que reciba como parámetro la interface de PageDialogService.
2.	En la parte donde se realiza la división, evaluamos el 2do número.
3.	Si este 2do es 0, mostramos un mensaje de validación en la pantalla.

 
Consumiendo Servicios

Agregamos los nuget de Newtonsoft.Json y Microsoft.Net.Http
 
 

Creamos una clase de tipo DTO (Data Transfer Object) para manejo de los registros devueltos por el API
public class FotosDto
    {
        public int Id { get; set; }

        public int AlbumId { get; set; }

        public string Title { get; set; }

        public string Url { get; set; }

        public string ThumbnailUrl { get; set; }
    }

Creamos una clase genérica para la obtención de datos del servicio
public class WSClient
    {
        public async Task<T> Get<T>(string url)
        {
            HttpClient client = new HttpClient();
            var response = await client.GetAsync(url);
            var json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(json);
        }
    }
Modificamos la pagina de ListaRest para mostrar los registros
<?xml version="1.0" encoding="utf-8" ?>
<ContentPage xmlns="http://xamarin.com/schemas/2014/forms"
             xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
             xmlns:prism="clr-namespace:Prism.Mvvm;assembly=Prism.Forms"
             prism:ViewModelLocator.AutowireViewModel="True"
             x:Class="EndavaForms.Views.ListaRest"
             Title="{Binding Title}">

    <ListView Margin="10"
              ItemsSource="{Binding Registros, Mode=OneWay}"
              IsRefreshing="{Binding IsBusy, Mode=OneWay}">
        <ListView.ItemTemplate>
            <DataTemplate>
                <ImageCell
                    Text="{Binding Title}"
                    ImageSource="{Binding ThumbnailUrl}"></ImageCell>
            </DataTemplate>
        </ListView.ItemTemplate>
        
    </ListView>
    
</ContentPage>

Modificamos el ViewModel de ListaRest para manejar el consumo del API
public class ListaRestViewModel : ViewModelBase
    {
        #region Atributos

        private ObservableCollection<FotosDto> _registros;

        #endregion

        #region Propiedades

        public ObservableCollection<FotosDto> Registros
        {
            get => _registros;
            set => SetProperty(ref _registros, value);
        }

        #endregion

        #region Commands

        #endregion

        #region Constructor

        public ListaRestViewModel(INavigationService navigationService, IPageDialogService dialogService) : base(navigationService, dialogService)
        {
            InstanciarObjetos();
        }

        #endregion

        #region Metodos Privados

        private void InstanciarObjetos()
        {
            Title = "Lista Rest";

            ConsumirServicio();
        }

        private async void ConsumirServicio()
        {
            Registros = new ObservableCollection<FotosDto>();
            IsBusy = true;
            try
            {
                List<FotosDto> result = await ObtenerRegistros();

                foreach (FotosDto lo in result)
                {
                    Registros.Add(lo);
                }
                
            }
            catch (Exception ex)
            {
                await DialogService.DisplayAlertAsync("Error", ex.Message, "OK");
            }
            IsBusy = false;
        }

        private async Task<List<FotosDto>> ObtenerRegistros()
        {
            WSClient client = new WSClient();
            return await client.Get<List<FotosDto>>("http://jsonplaceholder.typicode.com/photos");
        }

        #endregion

    }

Agregamos una ContentPage para visualizar un registro seleccionado y modificamos su ViewModel
<?xml version="1.0" encoding="utf-8" ?>
<ContentPage xmlns="http://xamarin.com/schemas/2014/forms"
             xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
             xmlns:prism="clr-namespace:Prism.Mvvm;assembly=Prism.Forms"
             prism:ViewModelLocator.AutowireViewModel="True"
             x:Class="EndavaForms.Views.RegistroRest"
             Title="{Binding Title}">

    <StackLayout Margin="10">

        <Label Text="{Binding ItemTitle, Mode=OneWay}"
               HorizontalOptions="CenterAndExpand"></Label>
        
        <Image Source="{Binding ImageUrl, Mode=OneWay}" WidthRequest="100" HeightRequest="100"></Image>
        
        
    </StackLayout>
  
</ContentPage>

public class RegistroRestViewModel : ViewModelBase
    {
        #region Atributos

        private string _itemTitle;

        private string _imageUrl;

        #endregion

        #region Propiedades

        public string ItemTitle
        {
            get => _itemTitle;
            set => SetProperty(ref _itemTitle, value);
        }

        public string ImageUrl
        {
            get => _imageUrl;
            set => SetProperty(ref _imageUrl, value);
        }

        #endregion

        #region Constructor

        public RegistroRestViewModel(INavigationService navigationService, IPageDialogService dialogService) : base(navigationService, dialogService)
        {
        }

        #endregion

        #region Metodos Privados

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            FotosDto registro = parameters.GetValue<FotosDto>("RegistroSeleccionado");

            if (registro != null)
            {
                Title = $"Id= {registro.Id}";
                ItemTitle = registro.Title;
                ImageUrl = registro.Url;
            }
        }

        #endregion
    }

Modificamos la ListaRest para que el ListView Tenga un SelectedItem y modificamos el ViewModel para que navegue a la nueva pagina y envie como parámetro el registro seleccioando
 
 
 
 



Local DB

Adicionamos el Nuget de Realm
 

Por un error del paquete, debemos adicionar manualmente el archivo FodyWeavers.xml en la raíz de todos los proyectos
<?xml version="1.0" encoding="utf-8" ?>
<Weavers>
  <RealmWeaver />
</Weavers>

Creamos un modelo de datos con el cual vamos a trabajar
public class Estudiantes : RealmObject
    {
        [PrimaryKey]
        public string Id { get; set; }

        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public DateTimeOffset FechaNacimiento { get; set; }

        public string NombreCompleto => $"{Nombre} {Apellido}";

        public string FechaDeNacimiento => FechaNacimiento.Date.ToShortDateString();
    }

Agregamos una ContentPage para visualizar los registros almacenados en una base de datos local y modificamos su ViewModel
<ContentPage xmlns="http://xamarin.com/schemas/2014/forms"
             xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
             xmlns:prism="clr-namespace:Prism.Mvvm;assembly=Prism.Forms"
             prism:ViewModelLocator.AutowireViewModel="True"
             x:Class="EndavaForms.Views.LocalDb"
             Title="{Binding Title}">

    <ContentPage.ToolbarItems>
        <ToolbarItem Order="Primary" Text="Nuevo" Priority="0"
                     Command="{Binding NuevoRegistroCommand}"/>
    </ContentPage.ToolbarItems>

    <ListView Margin="10"
              ItemsSource="{Binding Registros, Mode=OneWay}"
              IsRefreshing="{Binding IsBusy, Mode=OneWay}" >
        <ListView.ItemTemplate>
            <DataTemplate>
                <TextCell
                    Text="{Binding NombreCompleto}"
                    Detail="{Binding FechaDeNacimiento}"></TextCell>
            </DataTemplate>
        </ListView.ItemTemplate>

    </ListView>
</ContentPage>

using EndavaForms.Models;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using Realms;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace EndavaForms.ViewModels
{
    public class LocalDbViewModel : ViewModelBase
    {
        #region Atributos

        private ObservableCollection<Estudiantes> _registros;

        #endregion

        #region Propiedades

        public ObservableCollection<Estudiantes> Registros
        {
            get => _registros;
            set => SetProperty(ref _registros, value);
        }

        #endregion

        #region Commands

        public DelegateCommand NuevoRegistroCommand { get; set; }

        #endregion

        #region Constructor

        public LocalDbViewModel(INavigationService navigationService, IPageDialogService dialogService) : base(navigationService, dialogService)
        {
            InstanciarObjetos();
        }

        #endregion

        #region Metodos Privados

        private void InstanciarObjetos()
        {
            Title = "Local DB";

            NuevoRegistroCommand = new DelegateCommand(NuevoRegistro);

        }

        private void CargarRegistros()
        {
            Registros = new ObservableCollection<Estudiantes>();

            Realm realm = Realm.GetInstance();

            IEnumerable<Estudiantes> listaEstudiantes = realm.All<Estudiantes>();

            foreach (Estudiantes lo in listaEstudiantes)
            {
                Registros.Add(lo);
            }
        }

        private async void NuevoRegistro()
        {
            await NavigationService.NavigateAsync("NuevoRegistro");
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            CargarRegistros();
        }

        #endregion
    }
}

Agregamos una ContentPage para agregar un nuevo registro a la base de datos local y modificamos su ViewModel
<ContentPage xmlns="http://xamarin.com/schemas/2014/forms"
             xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
             xmlns:prism="clr-namespace:Prism.Mvvm;assembly=Prism.Forms"
             prism:ViewModelLocator.AutowireViewModel="True"
             x:Class="EndavaForms.Views.NuevoRegistro"
             Title="{Binding Title}">

    <Grid Margin="10" VerticalOptions="FillAndExpand">
        <Grid.RowDefinitions>
            <RowDefinition Height="1*"></RowDefinition>
            <RowDefinition Height="Auto"></RowDefinition>
        </Grid.RowDefinitions>

        <StackLayout Grid.Row="0">

            <Label HorizontalOptions="CenterAndExpand"
                   Text="Nuevo"
                   FontSize="30"></Label>
            
            <Label Text="Nombre"></Label>
            <Entry Text="{Binding Nombre, Mode=TwoWay}"></Entry>

            <Label Text="Apellido"></Label>
            <Entry Text="{Binding Apellido, Mode=TwoWay}"></Entry>

            <Label Text="Fecha Nacimiento"></Label>
            <DatePicker Date="{Binding FechaNacimiento, Mode=TwoWay}" ></DatePicker>
        </StackLayout>

        <Button Grid.Row="1" 
                Text="Guardar" CornerRadius="20"
                BackgroundColor="Green"
                Command="{Binding GuardarCommand}"></Button>

    </Grid>

</ContentPage>

using EndavaForms.Models;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using Realms;
using System;
using System.Text;

namespace EndavaForms.ViewModels
{
    public class NuevoRegistroViewModel : ViewModelBase
    {
        #region Atributos

        private string _nombre;

        private string _apellido;

        private DateTime _fechaNacimiento;

        #endregion

        #region Propiedades

        public string Nombre
        {
            get => _nombre;
            set => SetProperty(ref _nombre, value);
        }

        public string Apellido
        {
            get => _apellido;
            set => SetProperty(ref _apellido, value);
        }

        public DateTime FechaNacimiento
        {
            get => _fechaNacimiento;
            set => SetProperty(ref _fechaNacimiento, value);
        }

        #endregion

        #region Commands

        public DelegateCommand GuardarCommand { get; set; }

        #endregion

        #region Contructor

        public NuevoRegistroViewModel(INavigationService navigationService, IPageDialogService dialogService) : base(navigationService, dialogService)
        {
            InstanciarObjetos();
        }

        #endregion

        #region Metodos Privados

        private void InstanciarObjetos()
        {
            Title = "Nuevo Registro";

            FechaNacimiento = DateTime.Today;

            GuardarCommand = new DelegateCommand(Guardar);
        }

        private async void Guardar()
        {
            string resultado = Validaciones();
            if (string.IsNullOrEmpty(resultado))
            {
                Realm realm = Realm.GetInstance();

                realm.Write(() =>
                {
                    realm.Add(new Estudiantes
                    {
                        Id = Guid.NewGuid().ToString(),
                        Nombre = Nombre,
                        Apellido = Apellido,
                        FechaNacimiento = new DateTimeOffset(FechaNacimiento)
                    });
                });

                await DialogService.DisplayAlertAsync("Guardar", "El registro se guardo de manera exitosa", "Ok");
                await NavigationService.GoBackAsync();
            }
            else
            {
                await DialogService.DisplayAlertAsync("Guardar", $"Se encontraron las siguientes validaciones:{Environment.NewLine}{resultado}", "Ok");
            }
        }

        private string Validaciones()
        {
            StringBuilder sb = new StringBuilder();
            if (string.IsNullOrEmpty(Nombre))
            {
                sb.AppendLine("Ingrese el nombre.");
            }
            if (string.IsNullOrEmpty(Apellido))
            {
                sb.AppendLine("Ingrese el apellido.");
            }
            if (FechaNacimiento.Date > DateTime.Today)
            {
                sb.AppendLine("La fecha de nacimiento no puede ser mayor al día actual.");
            }

            return sb.ToString();
        }

        #endregion

    }
}

 

 
