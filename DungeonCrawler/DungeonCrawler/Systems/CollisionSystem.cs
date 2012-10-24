﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DungeonCrawler.Components;
using Microsoft.Xna.Framework;

namespace DungeonCrawler.Systems
{
    public class CollisionSystem
    {
        private enum CollisionType
        {
            None = 0x0,
            Static = 0x1,
            Player = 0x2,
            Enemy = 0x4,
            Bullet = 0x8,
            PlayerEnemy = 0x6,
            PlayerBullet = 0xA,
            PlayerStatic = 0x3,
            EnemyBullet = 0xC,
            EnemyStatic = 0x5,
            BulletStatic = 0x9,
        }

        /// <summary>
        /// The parent game.
        /// </summary>
        private DungeonCrawlerGame _game;

        /// <summary>
        /// Creates a new collision system.
        /// </summary>
        /// <param name="game">The game this systems belongs to.</param>
        public CollisionSystem(DungeonCrawlerGame game)
        {
            _game = game;
        }

        /// <summary>
        /// Updates all the collisions currently in the game.
        /// </summary>
        /// <param name="elaspedTime">time since the last call to this method.</param>
        public void Update(float elaspedTime)
        {
            uint roomID;

            foreach (Player player in _game.PlayerComponent.All)
            {
                //Get all positions in the room.
                roomID = _game.PositionComponent[player.EntityID].RoomID;
                IEnumerable<Position> positionsInRoom = _game.PositionComponent.InRoom(roomID);

                foreach (Position position in positionsInRoom)
                {
                    IEnumerable<Position> collisions = positionsInRoom.InRegion(position.Center, position.Radius);
                    foreach(Position collidingPosition in collisions)
                    {
                        CollisionType type = getCollisionType(position.EntityID, collidingPosition.EntityID);
                        switch (type)
                        {
                            case CollisionType.Player:
                                PlayerPlayerCollision(position.EntityID, collidingPosition.EntityID);
                                break;
                            case CollisionType.PlayerEnemy:
                                PlayerEnemyCollision(position.EntityID, collidingPosition.EntityID);
                                break;
                            case CollisionType.PlayerBullet:
                                PlayerBulletCollision(position.EntityID, collidingPosition.EntityID);
                                break;
                            case CollisionType.PlayerStatic:
                                PlayerStaticCollision(position.EntityID, collidingPosition.EntityID);
                                break;
                            case CollisionType.Enemy:
                                EnemyEnemyCollision(position.EntityID, collidingPosition.EntityID);
                                break;
                            case CollisionType.EnemyBullet:
                                EnemyBulletCollision(position.EntityID, collidingPosition.EntityID);
                                break;
                            case CollisionType.EnemyStatic:
                                EnemyStaticCollision(position.EntityID, collidingPosition.EntityID);
                                break;
                            case CollisionType.BulletStatic:
                                BulletStaticCollision(position.EntityID, collidingPosition.EntityID);
                                break;
                        }
                    }
                }
            }
        }

        private void BulletStaticCollision(uint p, uint p_2)
        {
            throw new NotImplementedException();
        }

        private void EnemyStaticCollision(uint p, uint p_2)
        {
            throw new NotImplementedException();
        }

        private void EnemyBulletCollision(uint p, uint p_2)
        {
            throw new NotImplementedException();
        }

        private void EnemyEnemyCollision(uint p, uint p_2)
        {
            throw new NotImplementedException();
        }

        private void PlayerStaticCollision(uint p, uint p_2)
        {
            throw new NotImplementedException();
        }

        private void PlayerBulletCollision(uint p, uint p_2)
        {
            throw new NotImplementedException();
        }

        private void PlayerEnemyCollision(uint p, uint p_2)
        {
            throw new NotImplementedException();
        }

        private void PlayerPlayerCollision(uint p, uint p_2)
        {
            throw new NotImplementedException();
        }

        private CollisionType getCollisionType(uint p, uint p_2)
        {
            CollisionType obj1 = CollisionType.None;
            if (_game.PlayerComponent.Contains(p))
                obj1 = CollisionType.Player;
            else if (false) //Enemy
                obj1 = CollisionType.Enemy;
            else if (_game.BulletComponent.Contains(p))
                obj1 = CollisionType.Bullet;
            else if (false) //Static
                obj1 = CollisionType.Static;

            CollisionType obj2 = CollisionType.None;
            if (_game.PlayerComponent.Contains(p))
                obj2 = CollisionType.Player;
            else if (false) //Enemy
                obj2 = CollisionType.Enemy;
            else if (_game.BulletComponent.Contains(p))
                obj2 = CollisionType.Bullet;
            else if (false) //Static
                obj2 = CollisionType.Static;

            return obj1 | obj2;  
        }
    }
}
