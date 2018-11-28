//논리적 참조 영역
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


/*
 * 컨트롤러는 클래스라는 프로그래밍 기본 단위를 통해 코딩을 한다.
 * 하나의 클래스는 그 안에 여러 개의 기능과 특성(속성)을 가질 수 있고
 * 특히 컨트롤러 클래스는 브라우저로부터 호출되는 구체적인 대상인 메서드
 * (액션 메서드)를 통해 브라우저의 요청에 대한 데이터 호출 및 뷰(UI)를
 * 제어하는 기능을 제공한다.
 */


// < 컨트롤 클래스 정의 영역 >
namespace EddyHomePage.Controllers
{
    public class TestController : Controller
    {

        /*
         *                  < 액션 메소드 정의 영역 >
         * - 화면을 표현하는 뷰(화면-UI-웹 페이지)요소를 1:1로 생성
         * - 만들어진 뷰를 그냥 호출하거나 데이터를 전달하여 뷰 호출
         * - 데이터를 등록, 수정, 삭제, 조회 등의 작업 진행하여 그 데이터
         *   처리 결과를 뷰에 전달
         * - 오픈 API 방식으로 액션 메서드를 제공하고 결과를 JSON 포맷으로
         *   데이터를 전달함
         * - 비즈니스 로직을 처리하거나 비즈니스 로직 처리 전용 프로세스를
         *   호출함
         */

        // GET: Test
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Sample1()
        {
            return View();
        }

    }
}