using Logging.Attributes;
using Nancy;
using Nancy.ModelBinding;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ExempleWithNancy.Modules
{
    public class Person : NancyModule
    {
        public readonly Repository.Person repository;
        public Person()
        {
            repository = new Repository.Person();

            Get("/person/", _ =>
            {
                var ret = repository.GetAll();

                return repository.GetAll();
            });

            Get("/person/{id}", args =>
            {
                var ret = repository.Get(args.id);

                if (ret == null)
                    return 404;

                return ret;
            });

            Post("/person/", args =>
            {
                var person = this.Bind<Model.Person>();

                repository.Add(person);

                return person;
            });

            Put("/person/{id}", args =>
            {
                var person = this.Bind<Model.Person>();

                person.Id = args.id;

                repository.Edit(person);

                return person;
            });
        }
    }
}
