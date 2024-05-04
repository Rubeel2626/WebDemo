//using System;
//using System.Collections.Generic;
//using System.Data;
//using System.Data.SqlClient;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.Data.SqlClient;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.Extensions.Options;
//using WebDemo.Context.ApplicationDb;
//using WebDemo.Context.Model;

//namespace WebDemo.Controllers
//{
//	[Route("api/[controller]")]
//	[ApiController]
//	public class SchoolDetailsController : ControllerBase
//	{
//		private readonly ApplicationDBContext _context;
//		private readonly string connectionString;

//		public SchoolDetailsController(ApplicationDBContext context, IOptions<AppSetting> options)
//		{
//			_context = context;
//			connectionString = options.Value.WebDemoContext!;
//		}

//		// GET: api/SchoolDetails
//		[HttpGet]
//		public async Task<ActionResult<IEnumerable<dynamic>>> GetSchoolDetails()
//		{
//			using (var con = new System.Data.SqlClient.SqlConnection(connectionString))
//			using (var sqlCommand = new System.Data.SqlClient.SqlCommand("proc_SchoolDetails", con))
//			{
//				sqlCommand.CommandType = CommandType.StoredProcedure;
//				sqlCommand.Parameters.AddWithValue("@OpCode", 6);
//				using (var rd = new System.Data.SqlClient.SqlDataAdapter(sqlCommand))
//				{
//					var dt = new DataTable();
//					rd.Fill(dt);
//					return Ok(dt);

//				}
//			}
//		}

//		// GET: api/SchoolDetails/5
//		[HttpGet("{id}")]
//		public async Task<ActionResult<SchoolDetails>> GetSchoolDetails(int id)
//		{
//			if (_context.SchoolDetails == null)
//			{
//				return NotFound();
//			}
//			var schoolDetails = await _context.SchoolDetails.FindAsync(id);

//			if (schoolDetails == null)
//			{
//				return NotFound();
//			}

//			return schoolDetails;
//		}

//		// PUT: api/SchoolDetails/5
//		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
//		[HttpPut("{id}")]
//		public async Task<IActionResult> PutSchoolDetails(int id, SchoolDetails schoolDetails)
//		{
//			using (var con = new System.Data.SqlClient.SqlConnection(connectionString))
//			using (var sqlCommand = new System.Data.SqlClient.SqlCommand("proc_SchoolDetails", con))
//			{
//				sqlCommand.CommandType = CommandType.StoredProcedure;
//				sqlCommand.Parameters.AddWithValue("@Id", id);
//				sqlCommand.Parameters.AddWithValue("@SchoolId", schoolDetails.SchoolId);
//				sqlCommand.Parameters.AddWithValue("@ClassId", schoolDetails.ClassId);
//				sqlCommand.Parameters.AddWithValue("@StreamName", schoolDetails.StreamName);
//				sqlCommand.Parameters.AddWithValue("@IsDefault", schoolDetails.IsDefault);
//				sqlCommand.Parameters.AddWithValue("@FileUrl", schoolDetails.FileUrl);
//				sqlCommand.Parameters.AddWithValue("@OpCode", 4);
//				await con.OpenAsync();
//				await sqlCommand.ExecuteNonQueryAsync();
//			}
//			return Ok(new { Status = 1 });

//		}

//		// POST: api/SchoolDetails
//		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
//		[HttpPost(nameof(PostSchoolDetails))]
//		public async Task<ActionResult<SchoolDetails>> PostSchoolDetails(SchoolDetails schoolDetails)
//		{
//			using (var con = new System.Data.SqlClient.SqlConnection(connectionString))
//			using (var sqlCommand = new System.Data.SqlClient.SqlCommand("proc_SchoolDetails", con))
//			{
//				sqlCommand.CommandType = CommandType.StoredProcedure;
//				sqlCommand.Parameters.AddWithValue("@SchoolId", schoolDetails.SchoolId);
//				sqlCommand.Parameters.AddWithValue("@ClassId", schoolDetails.ClassId);
//				sqlCommand.Parameters.AddWithValue("@StreamName", schoolDetails.StreamName);
//				sqlCommand.Parameters.AddWithValue("@IsDefault", schoolDetails.IsDefault);
//				sqlCommand.Parameters.AddWithValue("@FileUrl", schoolDetails.FileUrl);
//				sqlCommand.Parameters.AddWithValue("@OpCode", 3);
//				await con.OpenAsync();
//				await sqlCommand.ExecuteNonQueryAsync();
//			}


//			//if (_context.SchoolDetails == null)
//			//{
//			//	return Problem("Entity set 'ApplicationDBContext.SchoolDetails'  is null.");
//			//}
//			//_context.SchoolDetails.Add(schoolDetails);
//			//await _context.SaveChangesAsync();

//			return Ok(new
//			{
//				status = 1

//			});
//		}

//		// DELETE: api/SchoolDetails/5
//		[HttpDelete("{id}")]
//		public async Task<IActionResult> DeleteSchoolDetails(int id)
//		{
//			using (var con = new System.Data.SqlClient.SqlConnection(connectionString))
//			using (var sqlCommand = new System.Data.SqlClient.SqlCommand("proc_SchoolDetails", con))
//			{
//				sqlCommand.CommandType = CommandType.StoredProcedure;
//				sqlCommand.Parameters.AddWithValue("@Id", id);				
//				sqlCommand.Parameters.AddWithValue("@OpCode", 5);
//				await con.OpenAsync();
//				await sqlCommand.ExecuteNonQueryAsync();
//			}
//			return Ok(new { Status = 1 });
//		}

//		private bool SchoolDetailsExists(int id)
//		{
//			return (_context.SchoolDetails?.Any(e => e.Id == id)).GetValueOrDefault();
//		}
//	}
//}
