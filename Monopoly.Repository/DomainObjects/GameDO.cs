﻿namespace Monopoly.Repository.DomainObjects
{
    public class GameDO
    {
        public long? Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public bool IsCompleted { get; set; }
        public GameDO(long? id, string name, string description, bool isCompleted)
        {
            Id = id;
            Name = name;
            Description = description;
            IsCompleted = isCompleted;
        }
        public GameDO(string name, string description) 
            : this(null, name, description, false) { }
        public GameDO(long? id, string name, string description, long isCompleted)
            : this(id, name, description, isCompleted==1?true:false) { }
    }
}
