using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Runtime.Serialization;
using System.Data.Linq.Mapping;

namespace KorisniAlati
{
    [Serializable]
public class Address
{
#region Konstruktor

public Address():base()
{
    this.rowVersion = new byte[8];
    SetNew();
}

#endregion

#region Chlanovi

private Int32 _AddressID;
private String _AddressLine1;
private String _AddressLine2;
private String _City;
private Int32 _StateProvinceID;
private String _PostalCode;
private Object _SpatialLocation;
private Guid _rowguid;
private DateTime _ModifiedDate;

protected byte[] rowVersion = null;
protected bool isNew = false;
protected bool isDirty = false;
protected bool isDeleted = false;

[NonSerialized]
protected object originalValue = null; 

#endregion

#region Osobine

public virtual Int32 AddressID {
      get { return _AddressID ; }
      set 
      {
         if(_AddressID != value)
         {
             _AddressID=value;
            SetDirty();
         }
      }}
public virtual String AddressLine1 {
      get { return _AddressLine1 ; }
      set 
      {
         if(_AddressLine1 != value)
         {
             _AddressLine1=value;
            SetDirty();
         }
     }}
public virtual String AddressLine2 {
      get { return _AddressLine2 ; }
      set 
      {
         if(_AddressLine2 != value)
         {
             _AddressLine2=value;
            SetDirty();
         }
      }}
public virtual String City
{
    get { return _City; }
    set
    {
        if (_City != value)
        {
            _City = value;
            SetDirty();
        }
    }
}
public virtual Int32 StateProvinceID {
      get { return _StateProvinceID ; }
      set 
      {
         if(_StateProvinceID != value)
         {
             _StateProvinceID=value;
            SetDirty();
         }
      }}
public virtual String PostalCode {
      get { return _PostalCode ; }
      set 
      {
         if(_PostalCode != value)
         {
             _PostalCode=value;
            SetDirty();
         }
      }}
public virtual Object SpatialLocation {
      get { return _SpatialLocation ; }
      set 
      {
         if(!_SpatialLocation.Equals(value))
         {
             _SpatialLocation=value;
            SetDirty();
         }
      }}
public virtual Guid rowguid {
      get { return _rowguid ; }
      set 
      {
         if(_rowguid != value)
         {
             _rowguid=value;
            SetDirty();
         }
      }}
public virtual DateTime ModifiedDate {
      get { return _ModifiedDate ; }
      set 
      {
         if(_ModifiedDate != value)
         {
             _ModifiedDate=value;
            SetDirty();
         }
      }}
[Column (Name = "RowVersion", IsPrimaryKey = false, DbType = "timestamp", IsDbGenerated = false, CanBeNull = false)]
public byte[] RowVersion
{
    get { return this.rowVersion; }
    set
    {
        if (this.rowVersion != value)
        {
            this.rowVersion = value;
            SetDirty();
        }
    }
}

#endregion

#region nadjacane Osobine

public bool IsDirty
{
      get { return this.isDirty; }
}
public bool IsNew
{
    get { return this.isNew; }
}

public bool IsDeleted
{
    get { return this.isDeleted; }
}
#endregion

#region nadjacane Metode
public void SetNew()
{
    this.isNew = true;
    this.isDeleted = false;
    SetDirty();
}
public void SetClean()
{
      this.isDirty = false;
}
public void SetDirty()
{
      this.isDirty = true;
}
public void SetOld()
{
      this.isNew = false;
}
protected object Copy(object src, object dst)
{
         Address from = (Address)src;
         Address to = (Address)dst;

         to.rowVersion = from.rowVersion;

         to.isNew = from.isNew;
         to.isDirty = from.isDirty;
         to.isDeleted = from.isDeleted;

         to._AddressID = from._AddressID;
         to._AddressLine1 = from._AddressLine1;
         to._AddressLine2 = from._AddressLine2;
         to._City = from._City;
         to._StateProvinceID = from._StateProvinceID;
         to._PostalCode = from._PostalCode;
         to._SpatialLocation = from._SpatialLocation;
         to._rowguid = from._rowguid;
         to._ModifiedDate = from._ModifiedDate;

         return dst;
}
public object Clone()
      {
         Address clone = (Address)Copy(this, new Address());
         return clone;
      }
public bool Validate(out string message)
{
      bool validno = true;
      message = string.Empty;
      
      return validno;
}
public void BeginEdit()
{
    this.originalValue = Clone();
}

public void EndEdit()
{
    this.originalValue = null;
}

public void CancelEdit()
{
    if (this.originalValue != null)
    {
        Copy(this.originalValue, this);
        this.originalValue = null;
    }
}

#endregion

#region Jednachenja

public int GetHashCode()
{
      return base.GetHashCode();
}
public bool Equals(object obj)
{
      if ((obj == null) || (GetType() != obj.GetType()))
      {
         return false;
      }
      Address ps = (Address)obj;
      return this.AddressID == ps.AddressID;
}
public static bool operator ==(Address po1, Address po2)
{
      if ((ReferenceEquals(po1, null)))
      {
         return ReferenceEquals(po2, null);
      }
      else
      {
         return po1.Equals(po2);
      }
}
public static bool operator !=(Address po1, Address po2)
{
      return !(po1 == po2);
}

#endregion

}

}
