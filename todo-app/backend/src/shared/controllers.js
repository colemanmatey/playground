/**
 * Shared Controllers
 */

import HTTP_CODES from "../config/httpcodes.js";

// CRUD Controller
export class CRUDController {

    constructor(service, db) {
        this.service = service;
        this.db = db;
    }

    execute = async (req, res, action, status) => {
        try {
            const result = await this.db(client => action(client, req));
            res.status(status.success).send(result);
        } catch (error) {
            res.status(status.failure).send({ error: error.message });
        }
    }
    
    create = async (req, res) => {
        const status = { 
            success: HTTP_CODES.CREATED, 
            failure: HTTP_CODES.BAD_REQUEST 
        }
        await this.execute(req, res, client => this.service.create(client, req.body), status)
    }
    
    getAll = async (req, res) => {
        const status = { 
            success: HTTP_CODES.OK, 
            failure: HTTP_CODES.INTERNAL_SERVER_ERROR 
        }
        await this.execute(req, res, client => this.service.getAll(client, req.body), status)

    }

    getByID = async (req, res) => {
        const status = { 
            success: HTTP_CODES.OK, 
            failure: HTTP_CODES.INTERNAL_SERVER_ERROR 
        }
        await this.execute(req, res, client => this.service.getByID(client, req.params.id), status)
    }

    updateFields = async (req, res) => {
        const status = { 
            success: HTTP_CODES.OK, 
            failure: HTTP_CODES.INTERNAL_SERVER_ERROR 
        }     
        await this.execute(req, res, client => this.service.updateFields(client, req.body), status)
    }
    
    updateRecord = async (req, res) => {
        const status = { 
            success: HTTP_CODES.OK, 
            failure: HTTP_CODES.INTERNAL_SERVER_ERROR 
        }       
        await this.execute(req, res, client => this.service.updateRecord(client, req.body), status)
    }

    deleteByID = async (req, res) => {
        const status = { 
            success: HTTP_CODES.OK, 
            failure: HTTP_CODES.INTERNAL_SERVER_ERROR 
        }       
        await this.execute(req, res, client => this.service.removeByID(client, req.params.id), status)
    }
}
