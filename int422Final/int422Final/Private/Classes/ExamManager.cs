using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Objects;
using System.Data.Objects.DataClasses;
using System.Data.EntityClient;
using System.ComponentModel;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using System.Data;
using System.Web.Security;
using System.Text.RegularExpressions;
using System.Drawing;
using System.IO;
using System.Security.Principal;

namespace int422Final.Private.Classes
{
    public class ExamManager
    {
        /// <summary>
        /// adds a new customer
        /// </summary>
        public static void addCustomer(string customerId,string password, string fName, string lName, string licenceType)
        {
            if (fName == null)
            {
                throw new FirstNameMustNotBeBlank();
            }

            if (lName == null)
            {
                throw new LastNameMustNotBeBlank();
            }

            if (password == null)
            {
                throw new PasswordMustNotBeBlank();
            }

            if (licenceType == null)
            {
                throw new LicenseTypeMustNotBeBlank();
            }

            if (licenceType != "car" && licenceType != "truck" && licenceType != "both")
            {
                throw new LicenseTypeMustBeCarTruckOrBoth();
            }

            var context = new int422Final.Private.Models.exam_Entities();

            bool valid = false;

            try
            {
                //if the custmoer ID does not exist, this statement throws an exception
                var check = context.v_Customer.Where(i => i.customer_id == customerId).First();

            }
            catch
            {
                //if we did not find the customer_id
                valid = true;
            }

            //if valid is false, the ID is already in the customer table
            //throw our custom exception
            if (valid == false)
            {
                if (context.Connection.State == ConnectionState.Open)
                {
                    context.Dispose();
                }

                throw new CustomerIdMustBeUnique();
            }


            try
            {
                //add the new customer
                context.v_Customer.AddObject(new int422Final.Private.Models.v_Customer() { customer_id = customerId, c_password = password, l_name = lName, f_name = fName, licence_type = licenceType });
                //commit
                context.SaveChanges();

            }
            catch
            {
                throw new UnableToAddNewCustomer();
            }
        }

throw new UnableToAddNewCustomer();


        /// <summary>
        /// adds a new Model
        /// </summary>
        public static void addModel(string modelId,string vehicleType)
        {
            if (vehicleType == null)
            {
                throw new VehicleTypeMustNotBeBlank();
            }

            if (vehicleType != "car" && vehicleType != "truck")
            {
                throw new VehicleTypeMustBeCarOrTruck();
            }

            var context = new int422Final.Private.Models.exam_Entities();

            bool valid = false;

            try
            {
                //if the model ID does not exist, this statement throws an exception
                var check = context.v_Vehicle_Model.Where(i => i.model_id == modelId).First();

            }
            catch
            {
                //if we did not find the model_id
                valid = true;
            }

            //if valid is false, the ID is already in the model table
            //throw our custom exception
            if (valid == false)
            {
                if (context.Connection.State == ConnectionState.Open)
                {
                    context.Dispose();
                }

                throw new ModelIdMustBeUnique();
            }

            try
            {
                //add the new model
                context.v_Vehicle_Model.AddObject(new int422Final.Private.Models.v_Vehicle_Model() { model_id = modelId, vehicle_type = vehicleType });
                //commit
                context.SaveChanges();

            }
            catch
            {
                throw new UnableToAddNewModel();
            }           
        }


        /// <summary>
        /// adds a new vehicle 
        /// </summary>
        public static void addNewVehicle(string modelId,string customerId,string Colour,string Trans)
        {           
            if (Colour == null)
            {
                throw new ColourMustNotBeBlank();
            }

            if (Trans == null)
            {
                throw new TransMustNotBeBlank();
            }

            if (Trans != "auto" && Trans != "manual")
            {
                throw new TransMustBeAutoOrManual();
            }

            var context = new int422Final.Private.Models.exam_Entities();

            try
            {
                //if the custmoer ID does not exist, this statement throws an exception
                var check = context.v_Customer.Where(i => i.customer_id == customerId).First();

            }
            catch
            {
                if (context.Connection.State == ConnectionState.Open)
                {
                    context.Dispose();
                }

                throw new CustomerIdMustAlreadyExist();
            }

            try
            {
                //if the model ID does not exist, this statement throws an exception
                var check = context.v_Vehicle_Model.Where(i => i.model_id == modelId).First();

            }
            catch
            {
                if (context.Connection.State == ConnectionState.Open)
                {
                    context.Dispose();
                }

                throw new ModelIdMustAlreadyExist();
            }


            bool Insured = true;

            var theCustomer = context.v_Customer.Where(i => i.customer_id == customerId).First();

            var theCustomerLicenceType = theCustomer.licence_type.Trim();

            var theModel = context.v_Vehicle_Model.Where(i => i.model_id == modelId).First();

            var theModelVehicleType = theModel.vehicle_type.Trim();

            if (theCustomerLicenceType != theModelVehicleType && theCustomerLicenceType != "both") 
            {
                Insured = false;

                throw new LicenseTypeMustMatchVehicleTypeOrIsBoth();
            }

            //add new vehicle into database
            try
            {
                //add the new vehicle
                context.v_Customer_Vehicle.AddObject(new int422Final.Private.Models.v_Customer_Vehicle() { model_id = modelId, customer_id = customerId, insured = Insured, color = Colour, trans = Trans });
                //commit
                context.SaveChanges();

            }
            catch
            {

                throw new UnableToAddNewModel();
            }           
            finally
            {
                if (context.Connection.State == ConnectionState.Open)
                {
                    context.Dispose();
                }
            }
        }

        public static void CreateDynamicTable(ContentPlaceHolder ContentPlaceHolder1,string customerId)
        {
            var context = new int422Final.Private.Models.exam_Entities();

                //if the model ID does not exist, this statement throws an exception
            var theVehicle = context.v_Customer_Vehicle.Where(i => i.customer_id == customerId).OrderBy(n => n.model_id);

            

            //ContentPlaceHolder1.Controls.Clear();


            // Create a Table and set its properties 
            Table tbl = new Table();
            // Add the table to the placeholder control
            ContentPlaceHolder1.Controls.Add(tbl);

            //add first table row
            TableRow tr = new TableRow();
            
                TableCell tc = new TableCell();
                TextBox txtBox = new TextBox();
                txtBox.Text = "Model ID";
                tc.Controls.Add(txtBox);
                tr.Cells.Add(tc);

                TableCell tc1 = new TableCell();
                TextBox txtBox1 = new TextBox();
                txtBox1.Text = "Color";
                tc1.Controls.Add(txtBox1);
                tr.Cells.Add(tc1);

                TableCell tc2 = new TableCell();
                TextBox txtBox2 = new TextBox();
                txtBox2.Text = "Transmission";
                tc2.Controls.Add(txtBox2);
                tr.Cells.Add(tc2);

                TableCell tc3 = new TableCell();
                TextBox txtBox3 = new TextBox();
                txtBox3.Text = "Insured";
                tc3.Controls.Add(txtBox3);
                tr.Cells.Add(tc3);

            
            tbl.Rows.Add(tr);

            foreach (var item in theVehicle)
            {
                
                        TableRow tr1 = new TableRow();
                    
                        TableCell tc4 = new TableCell();
                        TextBox txtBox4 = new TextBox();
                        txtBox4.Text = item.model_id;
                        // Add the control to the TableCell
                        tc4.Controls.Add(txtBox4);
                        // Add the TableCell to the TableRow
                        tr1.Cells.Add(tc4);
                    
                        TableCell tc5 = new TableCell();
                        TextBox txtBox5 = new TextBox();
                        txtBox5.Text = item.color;
                        // Add the control to the TableCell
                        tc5.Controls.Add(txtBox5);
                        // Add the TableCell to the TableRow
                        tr1.Cells.Add(tc5);

                        TableCell tc6 = new TableCell();
                        TextBox txtBox6 = new TextBox();
                        txtBox6.Text = item.trans;
                        // Add the control to the TableCell
                        tc6.Controls.Add(txtBox6);
                        // Add the TableCell to the TableRow
                        tr1.Cells.Add(tc6);

                        TableCell tc7 = new TableCell();
                        TextBox txtBox7 = new TextBox();
                        if (item.insured == true){
                            txtBox7.Text = "Yes";
                        }
                        if (item.insured == false){
                            txtBox7.Text = "No";
                        }
                        // Add the control to the TableCell
                        tc7.Controls.Add(txtBox7);
                        // Add the TableCell to the TableRow
                        tr1.Cells.Add(tc7);


                    // Add the TableRow to the Table
                    tbl.Rows.Add(tr1);
                }

            context.SaveChanges();
            }
        }


    }


public class FirstNameMustNotBeBlank : ApplicationException
{
    public FirstNameMustNotBeBlank(string msg = "First name must not be blank") : base(msg) { }
}

public class LastNameMustNotBeBlank : ApplicationException
{
    public LastNameMustNotBeBlank(string msg = "Last name must not be blank") : base(msg) { }
}

public class PasswordMustNotBeBlank : ApplicationException
{
    public PasswordMustNotBeBlank(string msg = "Password must not be blank") : base(msg) { }
}

public class LicenseTypeMustNotBeBlank : ApplicationException
{
    public LicenseTypeMustNotBeBlank(string msg = "License type must not be blank") : base(msg) { }
}

public class UnableToAddNewCustomer : ApplicationException
{
    public UnableToAddNewCustomer(string msg = "Unable to add new customer") : base(msg) { }
}

public class LicenseTypeMustBeCarTruckOrBoth : ApplicationException
{
    public LicenseTypeMustBeCarTruckOrBoth(string msg = "License type must be car, truck or both") : base(msg) { }
}

public class VehicleTypeMustNotBeBlank : ApplicationException
{
    public VehicleTypeMustNotBeBlank(string msg = "Vehicle type must not be blank") : base(msg) { }
}

public class VehicleTypeMustBeCarOrTruck : ApplicationException
{
    public VehicleTypeMustBeCarOrTruck(string msg = "Vehicle type must be car or truck") : base(msg) { }
}

public class UnableToAddNewModel : ApplicationException
{
    public UnableToAddNewModel(string msg = "Unable to add new model") : base(msg) { }
}

public class ColourMustNotBeBlank : ApplicationException
{
    public ColourMustNotBeBlank(string msg = "Colour must not be blank") : base(msg) { }
}

public class TransMustNotBeBlank : ApplicationException
{
    public TransMustNotBeBlank(string msg = "Trans must not be blank") : base(msg) { }
}

public class CustomerIdMustAlreadyExist : ApplicationException
{
    public CustomerIdMustAlreadyExist(string msg = "Customer id must already exist") : base(msg) { }
}

public class ModelIdMustAlreadyExist : ApplicationException
{
    public ModelIdMustAlreadyExist(string msg = "Model id must already exist") : base(msg) { }
}

public class CustomerIdMustBeUnique : ApplicationException
{
    public CustomerIdMustBeUnique(string msg = "Customer id must be unique") : base(msg) { }
}

public class ModelIdMustBeUnique : ApplicationException
{
    public ModelIdMustBeUnique(string msg = "Model id must be unique") : base(msg) { }
}

public class LicenseTypeMustMatchVehicleTypeOrIsBoth : ApplicationException
{
    public LicenseTypeMustMatchVehicleTypeOrIsBoth(string msg = "License type must match vehicle type or is both") : base(msg) { }
}

public class TransMustBeAutoOrManual : ApplicationException
{
    public TransMustBeAutoOrManual(string msg = "You must enter the transmission type, manual or auto ") : base(msg) { }
}





