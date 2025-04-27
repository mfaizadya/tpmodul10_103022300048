using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace tpmodul10_103022300048.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MahasiswaController : ControllerBase
    {
        private static List<Mahasiswa> mahasiswaList = new List<Mahasiswa>
    {
        new Mahasiswa { Nama = "Muhammad Faiz Adya", Nim = "103022300048" },
        new Mahasiswa { Nama = "Muhammad Rakan Yusra", Nim = "103022300048" },
        new Mahasiswa { Nama = "Raka Valrizqy Akhdansyah", Nim = "103022330096" },
        new Mahasiswa { Nama = "Naufal Fahreza", Nim = "103022330105" },
        new Mahasiswa { Nama = "Duhan Hasanain", Nim = "103022330080" }
    };

        [HttpGet]
        public IEnumerable<Mahasiswa> Get()
        {
            return mahasiswaList;
        }


        [HttpGet("{index}")]
        public ActionResult<Mahasiswa> Get(int index)
        {
            if (index < 0 || index >= mahasiswaList.Count)
                return NotFound();
            return mahasiswaList[index];
        }


        [HttpPost]
        public ActionResult Post([FromBody] Mahasiswa mahasiswa)
        {
            mahasiswaList.Add(mahasiswa);
            return CreatedAtAction(nameof(Get), new { index = mahasiswaList.Count - 1 }, mahasiswa);
        }

        [HttpDelete("{index}")]
        public IActionResult Delete(int index)
        {
            if (index < 0 || index >= mahasiswaList.Count)
                return NotFound();
            mahasiswaList.RemoveAt(index);
            return NoContent();
        }
    }
}
