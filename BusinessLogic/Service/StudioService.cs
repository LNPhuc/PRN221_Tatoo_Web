using BusinessLogic.IService;
using DataAccess.DataAccess;
using DataAccess.IRepository;
using DataAccess.IRepository.UnitOfWork;
using DataAccess.Repository;
using DataAccessObject.Utils;

namespace BusinessLogic.Service;

public class StudioService : IStudioService
{
    private readonly IUnitOfWork _unitOfWork;
    public StudioService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public Studio? Create(Studio studio)
    {
        var stu = _unitOfWork.Studio.GetById(studio.Id);
        var check = _unitOfWork.Studio.IsEmailExist(stu.StudioEmail);
        if(check == false)
        {
            return null;
        }
        var cre = _unitOfWork.Studio.Create(stu);
        _unitOfWork.Studio.SaveChanges();
        return cre;
    }

    public Studio Delete(Guid id)
    {
        var stu = _unitOfWork.Studio.GetById(id);
        stu.Status = "0";
        _unitOfWork.Studio.Update(stu);
        _unitOfWork.Studio.SaveChanges();
        return stu;
    }

    public Studio GetById(Guid id)
    {
        return _unitOfWork.Studio.GetById(id);
    }

    public Studio GetStudioByAccountId(Guid id)
    {
        return _unitOfWork.Studio.GetStudioByAccountId(id);
    }

    public Pagination<Studio> Search(string name, int pageIndex, int pageSize)
    {
        var stu = _unitOfWork.Studio.Search(name);
        return _unitOfWork.Studio.ToPagination(stu, pageIndex, pageSize);
    }

    public Studio Update(Guid id, Studio studio)
    {
        var stu = _unitOfWork.Studio.GetById(id);
        
        if(stu.StudioEmail == studio.StudioEmail && 
            stu.StudioPhone == studio.StudioPhone && 
            stu.Name == studio.Name &&
            stu.Address == studio.Address &&
            stu.Status == studio.Status) 
        {
            throw new Exception("Nothing change!");
        }


        /*else
        {
            stu.StudioEmail = studio.StudioEmail;
            stu.StudioPhone = studio.StudioPhone;
            stu.Name = studio.Name;
            stu.Address = studio.Address;
        }*/


        if(stu.StudioEmail != studio.StudioEmail){
            stu.StudioEmail = studio.StudioEmail;
            var checkEmail = _unitOfWork.Studio.IsEmailExist(stu.StudioEmail);
            if (checkEmail == true)
            {
                throw new Exception("Email used!");
            }
        }
        if(stu.StudioPhone != studio.StudioPhone)
        {
            stu.StudioPhone = studio.StudioPhone;
            var checkPhone = _unitOfWork.Studio.IsPhoneExist(stu.StudioPhone);
            if (checkPhone == true)
            {
                throw new Exception("Number phone used!");
            }
        }
        
        if(stu.Name != studio.Name)
        {
            stu.Name = studio.Name;
            var checkName = _unitOfWork.Studio.IsNameExist(stu.Name);
            if (checkName == true)
            {
                throw new Exception("Name studio used!");
            }
        }
        stu.Address = studio.Address;
        stu.Status = studio.Status;

        var update = _unitOfWork.Studio.Update(stu);
        _unitOfWork.Studio.SaveChanges();
        throw new Exception("Update completed!");
        return update;


    }
}