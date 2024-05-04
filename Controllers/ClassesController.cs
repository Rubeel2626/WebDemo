//using System;
//using System.Collections.Generic;
//using System.Data;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.Data.SqlClient;
//using Microsoft.EntityFrameworkCore;
//using WebDemo.Context.ApplicationDb;
//using WebDemo.Context.Model;

//namespace WebDemo.Controllers
//{
//	[Route("api/[controller]")]
//	[ApiController]
//	public class ClassesController : ControllerBase
//	{
//		private readonly ApplicationDBContext _context;

//		public ClassesController(ApplicationDBContext context)
//		{
//			_context = context;
//		}

//		// GET: api/Classes
//		[HttpGet]
//		public async Task<ActionResult<IEnumerable<Class>>> GetClass()
//		{
//			if (_context.Class == null)
//			{
//				return NotFound();
//			}
//			return await _context.Class.ToListAsync();
//		}

//		// GET: api/Classes/5
//		[HttpGet("{id}")]
//		public async Task<ActionResult<dynamic>> GetClass(int id)
//		{
//			using (var con = new System.Data.SqlClient.SqlConnection("Data Source =CT-RUBEEL;Initial Catalog = WebDemo;Integrated Security=True"))
//			using (var sqlCommand = new System.Data.SqlClient.SqlCommand("proc_SchoolDetails", con))
//			{
//				sqlCommand.CommandType = CommandType.StoredProcedure;
//				sqlCommand.Parameters.AddWithValue("@SchoolId", id);
//				sqlCommand.Parameters.AddWithValue("@OpCode", 2);				
//				using (var rd = new System.Data.SqlClient.SqlDataAdapter(sqlCommand))
//				{
//					var dt = new DataTable();
//					rd.Fill(dt);
//					return Ok(new
//					{
//						status = 1,
//						response = dt
//					});
//				}
//			}
//		}

//		// PUT: api/Classes/5
//		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
//		[HttpPut("{id}")]
//		public async Task<IActionResult> PutClass(int id, Class @class)
//		{
//			if (id != @class.Id)
//			{
//				return BadRequest();
//			}

//			_context.Entry(@class).State = EntityState.Modified;

//			try
//			{
//				await _context.SaveChangesAsync();
//			}
//			catch (DbUpdateConcurrencyException)
//			{
//				if (!ClassExists(id))
//				{
//					return NotFound();
//				}
//				else
//				{
//					throw;
//				}
//			}

//			return NoContent();
//		}

//		// POST: api/Classes
//		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
//		[HttpPost]
//		public async Task<ActionResult<Class>> PostClass(Class @class)
//		{
//			if (_context.Class == null)
//			{
//				return Problem("Entity set 'ApplicationDBContext.Class'  is null.");
//			}
//			_context.Class.Add(@class);
//			await _context.SaveChangesAsync();

//			return CreatedAtAction("GetClass", new { id = @class.Id }, @class);
//		}

//		// DELETE: api/Classes/5
//		[HttpDelete("{id}")]
//		public async Task<IActionResult> DeleteClass(int id)
//		{
//			if (_context.Class == null)
//			{
//				return NotFound();
//			}
//			var @class = await _context.Class.FindAsync(id);
//			if (@class == null)
//			{
//				return NotFound();
//			}

//			_context.Class.Remove(@class);
//			await _context.SaveChangesAsync();

//			return NoContent();
//		}

//		private bool ClassExists(int id)
//		{
//			return (_context.Class?.Any(e => e.Id == id)).GetValueOrDefault();
//		}
//	}
//}
