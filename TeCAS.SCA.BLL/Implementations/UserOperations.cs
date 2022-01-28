using System;
using System.Collections.Generic;
using System.Linq;
using TeCAS.SCA.BLL.Helpers;
using TeCAS.SCA.DAL;
using TeCAS.SCA.Entities;
using TeCAS.SCA.Services.Operations;
using static TeCAS.SCA.Entities.Enumerations.EnumerationLists;

namespace TeCAS.SCA.BLL.Implementations
{
    public class UserOperations : IUserOperations
    {
        public User AuthUser(string email, string password)
        {
            try
            {
                User Result = null;

                using (var Repository = RepositoryFactory.GetRepository())
                {
                    Result = Repository.Filter<User>(p => p.Email == email && p.Status == Status.ACTIVO).FirstOrDefault();
                    if (Result != null)
                    {
                        var encrypt = new EncryptHash();
                        bool band = encrypt.VerifyPasswordHash(password, Result.PasswordHash, Result.PasswordSalt);
                        if (!band)
                        {
                            Result = null;
                        }
                    }
                }

                return Result;
            }
            catch (Exception ex)
            {
                throw new Exception("Sucedio un error al autenticar el usuario. Favor de ingresar correctamente las credenciales " + ex);
            }
        }

        public User Create(User user, string password)
        {
            try
            {
                User Result = null;
                byte[] passwordHash, passwordSalt;
                using (var Repository = RepositoryFactory.GetRepository())
                {
                    var tmp = Find(user.Email);
                    if (tmp == null)
                    {
                        var encrypt = new EncryptHash();
                        encrypt.CreatePasswordHash(password, out passwordHash, out passwordSalt);
                        user.PasswordHash = passwordHash;
                        user.PasswordSalt = passwordSalt;
                        user.CreateAt = DateTime.UtcNow;
                        Result = Repository.Create(user);
                    }
                    else
                    {
                        throw new Exception("Ya existe un usuario registrado con el mismo correo electrónico");
                    }
                }

                return Result;
            }
            catch (Exception ex)
            {
                throw new Exception("Sucedio un error al registrar el usuario " + ex);
            }
        }

        public bool Delete(Guid id)
        {
            try
            {
                bool Result = false;
                User tmp = RetrieveById(id);
                if (tmp != null)
                {
                    using (var Repository = RepositoryFactory.GetRepository())
                    {
                        tmp.Status = Status.BAJA;
                        Result = Repository.Update(tmp);
                    }
                }
                else
                {
                    throw new Exception("El usuario que quiere eliminar no existe");
                }

                return Result;
            }
            catch (Exception ex)
            {

                throw new Exception("Sucedio un error al eliminar el usuario " + ex);
            }
        }

        public User Find(string email)
        {
            try
            {
                User Result = null;

                using (var Repository = RepositoryFactory.GetRepository())
                {
                    Result = Repository.Filter<User>(p => p.Email.ToUpper() == email.ToUpper()).FirstOrDefault();
                }

                return Result;
            }
            catch (Exception ex)
            {
                throw new Exception($"Sucedio un error al buscar al usuario con el correo electrónico { email } " + ex);
            }
        }

        public List<User> GetAll()
        {
            try
            {
                List<User> Result = null;

                using (var Repository = RepositoryFactory.GetRepository())
                {
                    Result = Repository.GetAll<User>();
                }

                return Result;
            }
            catch (Exception ex)
            {
                throw new Exception("Sucedio un error al obtener todos los usuarios " + ex);
            }
        }

        public User RetrieveById(Guid id)
        {
            try
            {
                User Result = null;
                using (var Repository = RepositoryFactory.GetRepository())
                {
                    Result = Repository.Retrieve<User>(p => p.Id == id);
                }

                return Result;
            }
            catch (Exception ex)
            {
                throw new Exception("Sucedio un error al buscar el usuario " + ex);
            }
        }

        public bool Update(User user)
        {
            try
            {
                bool Result = false;

                User tmp = RetrieveById(user.Id);
                using (var Repository = RepositoryFactory.GetRepository())
                {
                    if (tmp != null)
                    {
                        Result = Repository.Update(user);
                    }
                    else
                    {
                        throw new Exception("El usuario que quiere actualizar no existe");
                    }
                }

                return Result;
            }
            catch (Exception ex)
            {
                throw new Exception("Sucedio un error al actualizar el usuario " + ex);
            }
        }

        public bool UpdatePassword(User user, string password)
        {
            try
            {
                bool Result = false;
                byte[] passwordHash, passwordSalt;
                using (var Repository = RepositoryFactory.GetRepository())
                {
                    var tmp = Find(user.Email);
                    if (tmp != null)
                    {
                        var encrypt = new EncryptHash();
                        encrypt.CreatePasswordHash(password, out passwordHash, out passwordSalt);
                        user.PasswordHash = passwordHash;
                        user.PasswordSalt = passwordSalt;
                        Result = Repository.Update(user);
                    }
                    else
                    {
                        throw new Exception("El usuario al que quiere actualizar la contraseña no se encuentra registrado");
                    }
                }

                return Result;
            }
            catch (Exception ex)
            {
                throw new Exception("Sucedio un error al actualizar la contraseña del usuario " + ex);
            }
        }
    }
}
