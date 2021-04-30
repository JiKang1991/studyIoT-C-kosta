using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using MVCWebTest.Context;
using MVCWebTest.Models;

namespace MVCWebTest.Controllers
{
    public class MemberController : Controller
    {
        private MemberDAO db = new MemberDAO();

        // GET: Member
        public ActionResult Index()
        {
            return View(db.memberDBSet.ToList());
        }

        // GET: Member/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Member member = db.memberDBSet.Find(id);
            if (member == null)
            {
                return HttpNotFound();
            }
            return View(member);
        }

        // GET: Member/Create
        public ActionResult Create()
        {
            return View();
        }

        public string GetEncrypt(string str)
        {
            MD5 md = new MD5CryptoServiceProvider();
            byte[] bArr = md.ComputeHash(Encoding.Default.GetBytes(str));
            string temp = "";
            for(int i = 0; i < bArr.Length; i++)
            {
                // x2는 2자리의 16진수로 표기하라는 의미 입니다.
                // temp += bArr[i].ToString("x2");
                temp += $"{bArr[i]:x2}";
            }
            return temp;
        }

        // POST: Member/Create
        // 초과 게시 공격으로부터 보호하려면 바인딩하려는 특정 속성을 사용하도록 설정하세요. 
        // 자세한 내용은 https://go.microsoft.com/fwlink/?LinkId=317598을(를) 참조하세요.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,memberName,password,right")] Member member)
        {
            if (ModelState.IsValid)
            {
                string securityPw = GetEncrypt(member.password);
                member.password = securityPw;
                db.memberDBSet.Add(member);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(member);
        }

        // GET: Member/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Member member = db.memberDBSet.Find(id);
            if (member == null)
            {
                return HttpNotFound();
            }
            return View(member);
        }

        // POST: Member/Edit/5
        // 초과 게시 공격으로부터 보호하려면 바인딩하려는 특정 속성을 사용하도록 설정하세요. 
        // 자세한 내용은 https://go.microsoft.com/fwlink/?LinkId=317598을(를) 참조하세요.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,memberName,password,right")] Member member)
        {
            if (ModelState.IsValid)
            {
                db.Entry(member).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(member);
        }

        // GET: Member/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Member member = db.memberDBSet.Find(id);
            if (member == null)
            {
                return HttpNotFound();
            }
            return View(member);
        }

        // POST: Member/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Member member = db.memberDBSet.Find(id);
            db.memberDBSet.Remove(member);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
