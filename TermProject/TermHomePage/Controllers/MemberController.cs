using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TermHomePage.Models;
using System.Data.Entity;


namespace TermHomePage.Controllers
{
    public class MemberController : Controller
    {
        //객체 모델을 통한 DB 데이터 처리를 위한 관련 DB 객체를 상단에 정의함
        TermHomePageEntities db = new TermHomePageEntities();

        [HttpGet]
        public ActionResult Entry()
        {
            Members member = new Members();
            return View(member);
        }

        [HttpPost]
        public ActionResult Entry(Members member)
        {
            member.EntryDate = DateTime.Now;
            try
            {
                db.Members.Add(member);
                db.SaveChanges();
                ViewBag.Result = "OK";
            }
            catch (Exception ex)
            {
                ViewBag.Result = "FAIL";
            }
            return View(member);
            //return RedirectToAction("List", "Member");
        }



        /// <summary>
        /// 아이디 중복체크 
        /// </summary>
        /// <param name="memberid"></param>
        /// <returns></returns>
        public JsonResult IDCheck(string memberid)
        {
            string result = string.Empty;

            Members member = db.Members.Find(memberid);
            if (member == null)
            {
                result = "OK";
            }
            else
            {
                result = "FAIL";
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }


        [HttpGet]
        public ActionResult List()
        {
            List<Members> list = db.Members.OrderByDescending(o => o.EntryDate).ToList();
            //var list = db.Member.Where(c => c.MemberID == "EDDY" && c.MemberName == "강창훈").OrderByDescending(o => o.RegistDate).ToList();
            return View(list);
        }

        [HttpGet]
        public ActionResult Edit(string memberid)
        {
            Members member = db.Members.Where(c => c.MemberID == memberid).FirstOrDefault();
            return View(member);
        }

        [HttpPost]
        public ActionResult Edit(Members member)
        {
            Members dbMember = db.Members.Find(member.MemberID);
            try
            {
                dbMember.MemberName = member.MemberName;
                dbMember.MemberPWD = member.MemberPWD;
                dbMember.Email = member.Email;
                dbMember.Telephone = member.Telephone;

                db.Entry(dbMember).State = EntityState.Modified;
                db.SaveChanges();

                ViewBag.Result = "OK";
            }
            catch (Exception ex)
            {
                ViewBag.Result = "FAIL";
            }

            return View(dbMember);
        }


        [HttpGet]
        public ActionResult Delete(string memberid)
        {
            Members dbMember = db.Members.Find(memberid);
            db.Members.Remove(dbMember);
            db.SaveChanges();

            return RedirectToAction("List");
        }

        // GET: Member
        public ActionResult Index()
        {
            return View();
        }
    }
}