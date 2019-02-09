using System;
using Snarkorel.transnavi.client;
using System.Windows.Forms;
using Snarkorel.transnavi.client.response;
using System.Collections.Generic;
using System.Linq;

namespace Snarkorel.transnavi.enroute
{
    public partial class mainForm : Form
    {
        private TransnaviClient _client;
        private List<GetTransportTypeTreeResponseResult> _transportInfo;
        private List<VehicleInfo> _routeVehicleInfo;

        private const string BusLink = "http://fotobus.msk.ru/ajax2.php?action=index-qsearch&cid=1&type=1&num=";
        private const string TrolleybusLink = "http://transphoto.ru/ajax2.php?action=index-qsearch&cid=1&type=2&num=";
        private const string TramLink = "http://transphoto.ru/ajax2.php?action=index-qsearch&cid=1&type=1&num=";

        public mainForm()
        {
            InitializeComponent();
            DisableControls();
        }

        private void requestButton_Click(object sender, EventArgs e)
        {
            var login = string.Empty;
            var password = string.Empty;

            using (var credentialsForm = new CredentialsForm())
            {
                var result = credentialsForm.ShowDialog();
                if (result == DialogResult.OK)
                {
                    login = credentialsForm.Login;
                    password = credentialsForm.Password;
                }
                else
                {
                    MessageBox.Show("Ошибка авторизации!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Exit();
                }
            }

            _client = new TransnaviClient(login, password);

            var init = false;
            try
            {
                init = _client.Init();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка инициализации клиента Transnavi! " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
            
            if (!init)
            {
                MessageBox.Show("Ошибка инициализации клиента Transnavi!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }

            EnableControls();
            _transportInfo = _client.GetRoutesAndTransportTypes();
            transportTypeComboBox.SelectedIndex = 0;
        }

        private void transportTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            searchTextBox.Text = string.Empty;
            ResetVehicleInfo();
            RestoreRoutesList();
            ResetVehiclesList();
        }

        private void searchTextBox_TextChanged(object sender, EventArgs e)
        {
            ResetVehicleInfo();
            RestoreRoutesList();
            ResetVehiclesList();
            //TODO: rewrite bydlocode
            var items = new List<string>();
            foreach (var item in routesListBox.Items)
            {
                if (item.ToString().IndexOf(searchTextBox.Text) != -1)
                    items.Add(item.ToString());
            }
            routesListBox.Items.Clear();
            foreach (var item in items)
            {
                routesListBox.Items.Add(item);
            }
        }

        private void routesListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ResetVehicleInfo();
            ResetVehiclesList();
            int routeId = 0;
            var routeName = routesListBox.SelectedItem.ToString();
            var routeIdQuery = from route in _transportInfo[transportTypeComboBox.SelectedIndex].Routes
                               where (route.RouteName.Equals(routeName))
                               select route;

            routeId = Convert.ToInt32(routeIdQuery.FirstOrDefault().RouteId);

            _routeVehicleInfo = _client.GetRouteVehiclesInfo(routeId);

            vehiclesListBox.Items.Clear();

            foreach (var vehicle in _routeVehicleInfo)
            {
                vehiclesListBox.Items.Add(vehicle.GarageNumber);
            }
        }

        private void vehiclesListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var vehicleNum = vehiclesListBox.SelectedItem;
            
            var vehicleQuery = from vehicle in _routeVehicleInfo
                               where (vehicle.GarageNumber.Equals(vehicleNum))
                               select vehicle;
            var vehicleInfo = vehicleQuery.FirstOrDefault();

            if (vehicleInfo == null)
                return;

            var photoLink = string.Empty;
            if (vehicleInfo.TransportTypeId == "1")
                photoLink = BusLink + vehicleInfo.GarageNumber;
            if (vehicleInfo.TransportTypeId == "2")
                photoLink = TrolleybusLink + vehicleInfo.StateNumber;
            if (vehicleInfo.TransportTypeId == "3")
                photoLink = TramLink + vehicleInfo.StateNumber;

            var strings = new string[]
            {
                "Модель: " + vehicleInfo.VehicleModel,
                "Гос. номер: " + vehicleInfo.StateNumber,
                "Гаражный номер: " + vehicleInfo.GarageNumber,
                "Парк/депо: " + vehicleInfo.ParkName,
                "Направление движения: " + vehicleInfo.RouteDirection + " (" + vehicleInfo.FirstStopName + " - " + vehicleInfo.LastStopName + ")",
                "Поиск фото: " + photoLink + " "
            };
            var info = string.Join("\n", strings);
            vehicleInfoTextBox.Text = info;
        }

        private void ResetVehicleInfo()
        {
            vehicleInfoTextBox.Text = string.Empty;
        }

        private void ResetVehiclesList()
        {
            vehiclesListBox.Items.Clear();
        }

        private void RestoreRoutesList()
        {
            routesListBox.Items.Clear();
            var index = transportTypeComboBox.SelectedIndex;
            foreach (var route in _transportInfo[index].Routes)
            {
                routesListBox.Items.Add(route.RouteName);
            }
        }

        private void SetControlsEnabledState(bool state)
        {
            transportTypeComboBox.Enabled = state;
            searchTextBox.Enabled = state;
            routesListBox.Enabled = state;
            vehiclesListBox.Enabled = state;
            vehicleInfoTextBox.Enabled = state;
        }

        private void DisableControls()
        {
            SetControlsEnabledState(false);
        }

        private void EnableControls()
        {
            SetControlsEnabledState(true);
        }

        private void vehicleInfoTextBox_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(e.LinkText); //This should open default browser
        }
    }
}
