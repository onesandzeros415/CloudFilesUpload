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

            if (!SnetFalse.Checked & !SnetTrue.Checked)
            {
                Error.Text = "Please select true or false for ServiceNet";
            }
            else
            {
                //check to make sure a file is selected
                if (FileUpload1.HasFile)
                {
                    if (SnetTrue.Checked)
                    {
                        //create the path to save the file to
                        string fileName = Path.Combine(Server.MapPath("~/temp"), FileUpload1.FileName);
                        string path = Server.MapPath("~/temp");
                        bool snet = bool.Parse(SnetTrue.Text);

                        //save the file to our local path
                        FileUpload1.SaveAs(fileName);

                        try
                        {

                            var userCredentials = new UserCredentials(username, api_access_key);
                            var client = new CF_Client();
                            Connection conn = new CF_Connection(userCredentials, client);
                            conn.Authenticate(snet);

                            var container = new CF_Container(conn, client, ContainerNameText);
                            var obj = new CF_Object(conn, container, client, FileUpload1.FileName);

                            obj.WriteFromFile(fileName);

                            var list = container.GetObjects(true);

                            CFResultsGrid.DataSource = list;
                            CFResultsGrid.DataBind();

                            Error.Text = FileUpload1.FileName + " Has Been Uploaded Successfully";
                        }
                        catch (Exception ex)
                        {
                            Error.Text = "Authentication failed or You Simply Suck! <br /> <br />" + ex.ToString();
                        }
                    }
                    else if (SnetFalse.Checked)
                    {
                        //create the path to save the file to
                        string fileName = Path.Combine(Server.MapPath("~/temp"), FileUpload1.FileName);
                        string path = Server.MapPath("~/temp");
                        bool snet = bool.Parse(SnetFalse.Text);

                        //save the file to our local path
                        FileUpload1.SaveAs(fileName);

                        try
                        {

                            var userCredentials = new UserCredentials(username, api_access_key);
                            var client = new CF_Client();
                            Connection conn = new CF_Connection(userCredentials, client);
                            conn.Authenticate(snet);

                            var container = new CF_Container(conn, client, ContainerNameText);
                            var obj = new CF_Object(conn, container, client, FileUpload1.FileName);

                            obj.WriteFromFile(fileName);

                            var list = container.GetObjects(true);

                            CFResultsGrid.DataSource = list;
                            CFResultsGrid.DataBind();

                            Error.Text = FileUpload1.FileName + " Has Been Uploaded Successfully";
                        }
                        catch (Exception ex)
                        {
                            Error.Text = "Authentication failed or You Simply Suck! <br /> <br />" + ex.ToString();
                        }
                    }
                }
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
                            try
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
                            catch (Exception ex)
                            {
                                Error.Text = "Authentication failed or You Simply Suck! <br /> <br />" + ex.ToString();
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
                            try
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
                            catch (Exception ex)
                            {
                                Error.Text = "Authentication failed or You Simply Suck! <br /> <br />" + ex.ToString();
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
                Error.Text = "Authentication failed or You Simply Suck! <br /> <br />" + ex.ToString();
            }
        }
    }
}