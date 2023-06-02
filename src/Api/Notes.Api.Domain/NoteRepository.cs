using Microsoft.EntityFrameworkCore;
using Notes.Api.Data;
using Notes.Api.Domain.Exceptions;
using Notes.Api.Entities;

namespace Notes.Api.Domain;

public class NoteRepository : INoteRepository
{
    private readonly NoteDbContext _context;

    public NoteRepository(NoteDbContext context)
    {
        _context = context;
    }

    public NoteRepository(string _connectionString)
    {
        if (string.IsNullOrWhiteSpace(_connectionString)) throw new ArgumentNullException(nameof(_connectionString));

        _context = new NoteDbContext(_connectionString);        
    }


    public async Task<Note> AddAsync(Note entity)
    {
        if (entity == null) throw new ArgumentNullException(nameof(entity), "Note is null!");

        var n = await _context.Notes.AddAsync(entity);
        await _context.SaveChangesAsync();

        return n.Entity;
    }

    public Task<List<Note>> GetAllAsync()
    {
        var notes = _context.Notes
            .AsNoTracking()
            .ToListAsync();

        return notes;
    }

    public async Task<Note> GetById(int id)
    {
        var note = await _context.Notes
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id);

        if (note is null) throw new EntityNotFoundException();

        return note;
    }

    public async Task UpdateAsync(Note entity)
    {
        throw new NotImplementedException();
    }
}
