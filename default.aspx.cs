using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Rackspace.Cloudfiles;

namespace CloudFilesUpload
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnUpload_Click(object sender, EventArgs e)
        {
            string username = CFUsernameText.Text;
            string api_access_key = CFApiKeyText.Text;
            string ContainerNameText = CFContainerText.Text;
            try
            {
                //Check to make sure a service net value to selected
                if (!SnetFalse.Checked & !SnetTrue.Checked)
                {
                    Error.Text = "Please select true or false for ServiceNet";
                }
                else
                {
                    //Check to make sure a file is selected.
                    if (FileUpload1.HasFile)
                    {
                        //If service net is checked then continue.
                        if (SnetTrue.Checked)
                        {
                            //create the path to save the file to.
                            string fileName = Path.Combine(Server.MapPath("~/temp/"), FileUpload1.FileName);
                            string path = Server.MapPath("~/temp/");
                            //ServiceNet value taken from frontend.
                            bool snet = bool.Parse(SnetTrue.Text);

                            //Save the file to local path.
                            FileUpload1.SaveAs(fileName);

                            //Set CloudFiles credentials
                            var userCredentials = new UserCredentials(username, api_access_key);
                            var client = new CF_Client();
                            Connection conn = new CF_Connection(userCredentials, client);
                            conn.Authenticate(snet);

                            //Set container, and obj values
                            var container = new CF_Container(conn, client, ContainerNameText);
                            var obj = new CF_Object(conn, container, client, FileUpload1.FileName);

                            //CloudFiles binding writing from local object to CloudFiles
                            obj.WriteFromFile(fileName);

                            //Get list of object in container you just uploaded to
                            var list = container.GetObjects(true);

                            CFResultsGrid.DataSource = list;
                            CFResultsGrid.DataBind();

                            Error.Text = FileUpload1.FileName + " Has Been Uploaded Successfully";
                        }
                        else if (SnetFalse.Checked)
                        {
                            //create the path to save the file to.
                            string fileName = Path.Combine(Server.MapPath("~/temp/"), FileUpload1.FileName);
                            string path = Server.MapPath("~/temp/");
                            //ServiceNet value taken from frontend.
                            bool snet = bool.Parse(SnetTrue.Text);

                            //Save the file to local path.
                            FileUpload1.SaveAs(fileName);

                            //Set CloudFiles credentials
                            var userCredentials = new UserCredentials(username, api_access_key);
                            var client = new CF_Client();
                            Connection conn = new CF_Connection(userCredentials, client);
                            conn.Authenticate(snet);

                            //Set container, and obj values
                            var container = new CF_Container(conn, client, ContainerNameText);
                            var obj = new CF_Object(conn, container, client, FileUpload1.FileName);

                            //CloudFiles binding writing from local object to CloudFiles
                            obj.WriteFromFile(fileName);

                            //Get list of object in container you just uploaded to
                            var list = container.GetObjects(true);

                            CFResultsGrid.DataSource = list;
                            CFResultsGrid.DataBind();

                            Error.Text = FileUpload1.FileName + " Has Been Uploaded Successfully";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Error.Text = "Something went terribly wrong! See below for more info. <br /> <br />" + ex.ToString();
            }
        }
        protected void ListContainerContents_Click(object sender, EventArgs e)
        {
            string username = CFUsernameText.Text;
            string api_access_key = CFApiKeyText.Text;
            string ContainerNameText = CFContainerText.Text;

            try
            {
                if (!SnetFalse.Checked & !SnetTrue.Checked)
                {
                    Error.Text = "Please select true or false for ServiceNet";
                }
                else
                {
                    if (SnetTrue.Checked)
                    {
                        if (CFUsernameText.Text != "" & CFApiKeyText.Text != "" & CFContainerText.Text != "")
                        {
                            bool snet = bool.Parse(SnetTrue.Text);

                            var userCredentials = new UserCredentials(username, api_access_key);
                            var client = new CF_Client();
                            Connection conn = new CF_Connection(userCredentials, client);
                            conn.Authenticate(snet);
                            var container = new CF_Container(conn, client, ContainerNameText);
                            if (container.ObjectCount != 0)
                            {
                                var list = container.GetObjects(true);

                                CFResultsGrid.DataSource = list;
                                CFResultsGrid.DataBind();
                            }
                            else
                            {
                                Error.Text = "There is no content within this container.";
                            }

                        }
                        else
                        {
                            Error.Text = "Please be sure to enter Username, APIKey, and Container to upload to! <br /> <br />";
                        }
                    }
                    else if (SnetFalse.Checked)
                    {
                        if (CFUsernameText.Text != "" & CFApiKeyText.Text != "" & CFContainerText.Text != "")
                        {
                            bool snet = bool.Parse(SnetFalse.Text);

                            var userCredentials = new UserCredentials(username, api_access_key);
                            var client = new CF_Client();
                            Connection conn = new CF_Connection(userCredentials, client);
                            conn.Authenticate(snet);
                            var container = new CF_Container(conn, client, ContainerNameText);
                            if (container.ObjectCount != 0)
                            {
                                var list = container.GetObjects(true);

                                CFResultsGrid.DataSource = list;
                                CFResultsGrid.DataBind();
                            }
                            else
                            {
                                Error.Text = "There is no content within this container.";
                            }
                        }
                        else
                        {
                            Error.Text = "Please be sure to enter Username, APIKey, and Container to upload to! <br /> <br />";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Error.Text = "Something went terribly wrong! See below for more info. <br /> <br />" + ex.ToString();
            }
        }
    }
}