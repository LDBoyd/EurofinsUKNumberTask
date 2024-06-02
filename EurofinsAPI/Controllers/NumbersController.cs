using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EurofinsAPI.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Drawing;
using System.Security.Policy;
using Number = EurofinsAPI.Models.Number;
using System.Numerics;

namespace EurofinsAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class NumbersController : ControllerBase
    {

        private readonly EurofinsDbContext _context;

        private NumberCheckerFactory _numberChecker;

        private IReplaceNumber _numberReplacer;

        public NumbersController(EurofinsDbContext context)
        {
            _context = context;
            _numberChecker = new NumberCheckerFactory();
            _numberReplacer = new ReplaceNumber();

        }

        // POST: api/Numbers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<IEnumerable<object>>> PostNumber(Number number)
        {
            try
            {
                _context.Numbers.Add(number);
                await _context.SaveChangesAsync();

                List<object> numberList = new List<object>();

                int size = number.MaxValue - number.MinValue + 1;
                int maxVal = number.MaxValue;
                int minVal = number.MinValue;

                INumberChecker check3Multiple = _numberChecker.getCheckerType("3");
                INumberChecker check5Multiple = _numberChecker.getCheckerType("5");

                var currentNumber = number.MinValue;
                for (int i = 0; i < size; i++)
                {
                    bool is3Multiple = check3Multiple.checkNumber(currentNumber);
                    bool is5Multiple = check5Multiple.checkNumber(currentNumber);

                    if (is3Multiple && is5Multiple)
                    {
                        var addText = _numberReplacer.replaceNumber(0);
                        numberList.Add(addText);
                    }
                    else if (is3Multiple)
                    {
                        var addText = _numberReplacer.replaceNumber(3);
                        numberList.Add(addText);
                    }
                    else if (is5Multiple)
                    {
                        var addText = _numberReplacer.replaceNumber(5);
                        numberList.Add(addText);
                    }
                    else
                    {
                        numberList.Add(currentNumber);
                    }
                    currentNumber++;
                }

                return StatusCode(StatusCodes.Status200OK, numberList);

            } catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }

        }

    }

}
