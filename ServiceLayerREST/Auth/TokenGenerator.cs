﻿using System;
using System.Configuration;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using Share.Entities;

namespace ServiceLayerREST.Auth
{
    /// <summary>
    /// JWT Token generator class using "secret-key"
    /// more info: https://self-issued.info/docs/draft-ietf-oauth-json-web-token.html
    /// </summary>
    internal static class TokenGenerator
    {
        public static string GenerateTokenJwt(Usuario u)
        {
            if (u == null || u.persona == null)
                throw new Exception("Ni el Usuario ni la Persona no puede sre null");

            // appsetting for Token JWT
            var secretKey = ConfigurationManager.AppSettings["JWT_SECRET_KEY"];
            var audienceToken = ConfigurationManager.AppSettings["JWT_AUDIENCE_TOKEN"];
            var issuerToken = ConfigurationManager.AppSettings["JWT_ISSUER_TOKEN"];
            var expireTime = ConfigurationManager.AppSettings["JWT_EXPIRE_MINUTES"];

            var securityKey = new SymmetricSecurityKey(System.Text.Encoding.Default.GetBytes(secretKey));
            var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

            // create a claimsIdentity
            ClaimsIdentity claimsIdentity = new ClaimsIdentity(new[] {
                new Claim(ClaimTypes.Email, u.persona.correo),
                new Claim(ClaimTypes.Role, TokenGenerator.RolesDelUsuario(u)),
            });

            // create token to the user
            var tokenHandler = new System.IdentityModel.Tokens.Jwt.JwtSecurityTokenHandler();
            var jwtSecurityToken = tokenHandler.CreateJwtSecurityToken(
                audience: audienceToken,
                issuer: issuerToken,
                subject: claimsIdentity,
                notBefore: DateTime.UtcNow,
                expires: DateTime.UtcNow.AddMinutes(Convert.ToInt32(expireTime)),
                signingCredentials: signingCredentials);

            var jwtTokenString = tokenHandler.WriteToken(jwtSecurityToken);
            return jwtTokenString;
        }

        private static string RolesDelUsuario(Usuario u)
        {
            string roles = "usuario";
            if (u.persona.admin != null)     roles += ",admin";
            if (u.persona.conductor != null) roles += ",conductor";
            if (u.persona.superadmin!= null) roles += ",superadmin";
            return roles;
        }
    }
}