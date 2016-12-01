using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;

namespace EVE_Central.Basis
{
    public class MemberManagePage : System.Web.UI.Page
    {
        protected internal Model.siteconfig siteConfig;
        protected internal Model.member_setting set;

        public MemberManagePage()
        {
            this.Load += new EventHandler(memberload);
            siteConfig = new BLL.siteconfig().loadConfig();
        }
        private void memberload(object sender, EventArgs e)
        {
            //判断用户是否登陆
            if (!IsMemberLogin())
            {
                //Response.Write("<script>parent.location.href='" + siteConfig.webpath + "/a_member/login.aspx'</script>");
                string url = Request.Url.Authority.ToString();

                //Response.Write("<script>window.location.href='" + Request.Url.Authority.ToString() + "/a_member/login.aspx'</script>");
                //Response.Redirect("login.aspx");
                Response.Write("<script>parent.location.href='/a_member/login.aspx'</script>");
                Response.End();
            }


        }
        #region 用户基础方法=========================================================
        /// <summary>
        /// 判断用户是否登陆
        /// </summary>
        /// <returns></returns>
        public bool IsMemberLogin()
        {
            if (Session["Memberlogin"] != null)
            {
                return true;

            }
            else
            {
                //检查Cookies
                string membername = Utils.GetCookie("membername", "JinBo");
                string memberpwd = Utils.GetCookie("memberpwd", "JinBo");
                if (membername != "" && memberpwd != "")
                {
                    BLL.member bll = new BLL.member();
                    Model.member model = bll.CheckModle(membername, memberpwd);
                    set = new BLL.member_setting().GetModelByMid(model.id);
                    if (model != null)
                    {
                        Session["Memberlogin"] = model;
                        return true;
                    }
                    else
                    { return false; }
                }
                else
                    return false;
            }
        }
        /// <summary>
        /// 取得用户信息
        /// </summary>
        public Model.member GetMemberInfo()
        {
            if (IsMemberLogin())
            {
                Model.member model = Session["Memberlogin"] as Model.member;
                set = new BLL.member_setting().GetModelByMid(model.id);
                if (model != null)
                {
                    return model;
                }
            }
            return null;
        }
        /// <summary>
        /// 检查是否为管理员登陆
        /// </summary>
        /// <returns></returns>
        public bool Isadminlogin()
        {
            ManagePage mana = new ManagePage();

            if (mana.GetAdminInfo() == null)
                return true;
            else return false;
        }

        #endregion====================================================================
        #region JS提示============================================
        /// <summary>
        /// 添加编辑删除提示
        /// </summary>
        /// <param name="msgtitle">提示文字</param>
        /// <param name="url">返回地址</param>
        protected void JscriptMsg(string msgtitle, string url)
        {
            string msbox = "parent.jsprint(\"" + msgtitle + "\", \"" + url + "\")";
            ClientScript.RegisterClientScriptBlock(Page.GetType(), "JsPrint", msbox, true);
            Server.Transfer(url, true);
        }
        /// <summary>
        /// 带回传函数的添加编辑删除提示
        /// </summary>
        /// <param name="msgtitle">提示文字</param>
        /// <param name="url">返回地址</param>
        /// <param name="callback">JS回调函数</param>
        protected void JscriptMsg(string msgtitle, string url, string callback)
        {
            string msbox = "parent.jsprint(\"" + msgtitle + "\", \"" + url + "\", " + callback + ")";
            ClientScript.RegisterClientScriptBlock(Page.GetType(), "JsPrint", msbox, true);
        }
        #endregion
    }
}
