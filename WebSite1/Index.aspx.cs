using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using StudentCore.Domain;
using StudentCore.Controller;
using StudentCore.Common;

public partial class Index : System.Web.UI.Page
{
    List<Student> listStudent = null;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindCountryList();
            BindStudentList();
        }
    }


    private void BindCountryList()
    {
        CountryController countryController = ContollerFactory.CreateCountryController();
        ddlCountry.DataSource = countryController.GetCountryList();
        ddlCountry.DataValueField = "CountryCode";
        ddlCountry.DataTextField = "CountryName";
        ddlCountry.DataBind();
    }

    private void BindStudentList()
    {
        StudentController studentController = ContollerFactory.CreateStudentController();

        listStudent = studentController.GetStudentList(true);
        ViewState["listStudent"] = listStudent;
        gvStudent.DataSource = listStudent;
        gvStudent.DataBind();
    }

   
    protected void btnSave_Click(object sender, EventArgs e)
    {
        StudentController studentController = ContollerFactory.CreateStudentController();


        if (listStudent == null && ViewState["listStudent"] != null )
            listStudent = (List<Student>)ViewState["listStudent"];
        else
            listStudent = new List<Student>();

        if (btnSave.Text == "Update")
        {
            int rowIndex = (int)ViewState["updatedRowIndex"];
            listStudent[rowIndex].FirstName = txtFirstName.Text;
            listStudent[rowIndex].LastName = txtLastName.Text;
            listStudent[rowIndex].Email = txtEmail.Text;
            listStudent[rowIndex].CountryCode = ddlCountry.SelectedValue;
            listStudent[rowIndex].Gender = rbGender.SelectedValue;

          
            studentController.Update(listStudent[rowIndex]);
            Clear();
            btnSave.Text = "Save";
        }
        else
        {

            Student student = new Student();
            student.FirstName = txtFirstName.Text;
            student.LastName = txtLastName.Text;
            student.Email = txtEmail.Text;
            student.CountryCode = ddlCountry.SelectedValue;
            student.Gender = rbGender.SelectedValue;

           

            student.StudentId = studentController.Save(student);
            Clear();
            listStudent.Add(student);
        }
        ViewState["listStudent"] = listStudent;
        gvStudent.DataSource = listStudent;
        gvStudent.DataBind();
    }

    private void Clear()
    {
        txtFirstName.Text = string.Empty;
        txtLastName.Text = string.Empty;
        txtEmail.Text = string.Empty;
    }

    protected void btnEdit_Click(object sender, EventArgs e)
    {
        LinkButton test = (LinkButton)sender;

        GridViewRow gv = (GridViewRow)((LinkButton)sender).NamingContainer;


        int rowIndex = ((GridViewRow)((LinkButton)sender).NamingContainer).RowIndex;

        if (listStudent == null && ViewState["listStudent"] != null)
            listStudent = (List<Student>)ViewState["listStudent"];
        else
            listStudent = new List<Student>();


        txtFirstName.Text = listStudent[rowIndex].FirstName;
        txtLastName.Text = listStudent[rowIndex].LastName;
        txtEmail.Text = listStudent[rowIndex].Email;
        ddlCountry.SelectedValue = listStudent[rowIndex].CountryCode;
        rbGender.SelectedValue = listStudent[rowIndex].Gender;
        btnSave.Text = "Update";
        ViewState["updatedRowIndex"] = rowIndex;
       
    }
}