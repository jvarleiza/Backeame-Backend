using Backeame.Data.Repository;
using System;
using System.Collections.Generic;
using Backeame.Data;
using Backeame.Data.Interfaces;
using Backeame.Business;

namespace Backeame.Business.Implementation
{
    public class BaseLogic<TEntity> : IBaseLogic<TEntity>
        where TEntity : BaseEntity
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IRepository<TEntity> _currentRepository;

        public BaseLogic(IUnitOfWork UnitOfWork)
        {
            _unitOfWork = UnitOfWork;
            _currentRepository = _unitOfWork.GetRepository<TEntity>();
        }

        public bool Create(TEntity entity)
        {
            try
            {
                _currentRepository.Insert(entity);
                _unitOfWork.Save();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Delete(object id)
        {
            bool exists = _currentRepository.GetById(id) != null;
            if (exists)
            {
                try
                {
                    _currentRepository.Delete(id);
                    _unitOfWork.Save();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
            return false;
        }

        public bool Delete(TEntity entity)
        {
            try
            {
                _currentRepository.Delete(entity);
                _unitOfWork.Save();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public TEntity Get(object id)
        {
            return _currentRepository.GetById(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _currentRepository.Get();
        }

        public IEnumerable<TEntity> GetSegment(int page, int elementCount = 20)
        {
            return _currentRepository.GetSequence(elementCount, page * elementCount);
        }

        public bool Update(TEntity entity)
        {
            try
            {
                _currentRepository.Update(entity);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public void Dispose()
        {
            _unitOfWork.Dispose();
        }
    }
}

