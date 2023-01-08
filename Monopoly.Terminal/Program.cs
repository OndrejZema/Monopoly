using Monopoly.DAL;
using Monopoly.Repository.Repositories;
using Monopoly.Model.Entities;

MonopolyDbContext context = new MonopolyDbContext();
GameRepository repository = new GameRepository(context);
repository.Update(new Game() {Id=3, Name="Star Wars", Complete=1 });