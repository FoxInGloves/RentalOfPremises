using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using RentalOfPremises.Models.Data;
using RentalOfPremises.Repository.Abstraction;

namespace RentalOfPremises.Repository.Implementation;

public sealed class RentalRepository : IRepository
{
    private readonly DataBaseContext _context;

    public RentalRepository()
    {
        _context = new DataBaseContext();
    }

    public void Add(RentalData rentalData)
    {
        try
        {
            _context.PremisesTable.Add(rentalData);
            _context.SaveChanges();
        }
        catch (Exception e)
        {
            MessageBox.Show("Не удалось добавить");
            Console.WriteLine(e);
        }
    }

    public IList<RentalData> Read()
    {
        return _context.PremisesTable.ToList();
    }

    public void Update(RentalData rentalData)
    {
        try
        {
            var data = _context.PremisesTable.Find(rentalData.NamePremise);

            data.Contract = rentalData.Contract;
            data.Client = rentalData.Client;
            data.Price = rentalData.Price;
            data.StartDate = rentalData.StartDate;
            data.EndDate = rentalData.EndDate;
            data.Background = rentalData.Background;

            _context.SaveChanges();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            MessageBox.Show("Не удалось обновить");
        }
    }

    public void Delete(string namePremise)
    {
        try
        {
            var data = _context.PremisesTable.Find(namePremise);
            _context.PremisesTable.Remove(data);
            _context.SaveChanges();

        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            MessageBox.Show("Не удалось удалить");
        }
    }
}