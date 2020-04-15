using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebFormBasics
{
    /* Everytime page will be sent to server either through GET or POST, instance of this webform
     * will be created in memory and processing will happen*/
    public partial class ViewStateWebForm : System.Web.UI.Page
    {
        /* Author's Note: Keep only one of the below region uncommented at a time to see its effect */

        #region---- Without viewstate-----

        ///* Everytime this will be initialized to zero  */
        //int _clicksCount = 0;
        //protected void Page_Load(object sender, EventArgs e)
        //{
        //    if(!IsPostBack)
        //    {
        //        txtCount.Text = "0";
        //    }
        //}

        //protected void btnCount_Click(object sender, EventArgs e)
        //{
        //    /* On Every click, this will be incremented by 1, but since we are not storing _clicksCount updated value,
        //     it will take the initial value of zero and update it to 1 and not anything else.
        //     */
        //    _clicksCount += 1;
        //    /* So, on every subsequent click it will show 1 only and not anything else, since this webform instance will be
        //     * recreated, _clicksCount will be intialized to zero and incremented by 1 in button_click event method to give result 1. 
        //     * This happens because HTTP is stateless so, it doesn't remember anything from last request.
        //     * To make it remember, we need to store the value in ViewState
        //    */
        //    txtCount.Text = Convert.ToString(_clicksCount);
        //}

        #endregion

        #region -----With ViewState-----

        /* Initializing count to 1 */         
        int _clicksCount = 1;

        /* Store magic string or string literal in variable for strong typing and avoiding typing mistakes in multiple places */
        const string COUNT_STORED_IN_VIEWSTATE_KEY = "Count";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtCount.Text = "0";
            }
        }

        protected void btnCount_Click(object sender, EventArgs e)
        {
            /* On Every click, this will be incremented by 1, but since we are not storing _clicksCount updated value,
             it will take the initial value of zero and update it to 1 and not anything else.
             To see viewstate in webpage, right click on the page and select page source, then a hidden field named
             viewstate is visible with value stored in base64 encrypted form
             */
             if(ViewState[COUNT_STORED_IN_VIEWSTATE_KEY] != null)
            {
                _clicksCount += Convert.ToInt32(ViewState[COUNT_STORED_IN_VIEWSTATE_KEY]);
            }

            txtCount.Text = Convert.ToString(_clicksCount);

            /* Keep updated count in ViewState as it transfer with each request and response so we can know the current
             count in next request.
             Also, first time ViewState for this key will be null, so here it will also get intitialized for first time also*/
            ViewState[COUNT_STORED_IN_VIEWSTATE_KEY] = _clicksCount;
        }

        #endregion
    }
}