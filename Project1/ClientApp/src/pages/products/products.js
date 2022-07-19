import React from 'react';
import './products.scss';
import 'devextreme/data/odata/store';
import DataGrid, {
    Column,
    Pager,
    Paging,
    FilterRow,
    Lookup
} from 'devextreme-react/data-grid';


export default () => {
    const currencyFormat = { style: 'currency', currency: 'RUB', useGrouping: true, minimumSignificantDigits: 3 };

    return (<React.Fragment>
        <h2 className={'content-block'}>Товары</h2>
        <div className={'content-block'}>
            <div className={'dx-card responsive-paddings'}>
                <DataGrid
                    className={'dx-card wide-card'}
                    dataSource={dataSource}
                    showBorders={false}
                    focusedRowEnabled={true}
                    defaultFocusedRowIndex={0}
                    columnAutoWidth={true}
                    columnHidingEnabled={true}
                >
                    <Paging defaultPageSize={5} />
                    <Pager showPageSizeSelector={true} showInfo={true} />
                    <FilterRow visible={true} />

                    <Column dataField={'recId'} />
                    <Column
                        dataField={'productName'}
                        caption={'Наименование продукта'}
                    />
                    <Column
                        dataField={'initPrice'}
                        caption={'Цена закупки'}
                        format={currencyFormat}
                    />
                    <Column
                        dataField={'price'}
                        caption={'Цена продажи'}
                        format={currencyFormat}
                    />

                </DataGrid>
            </div>
        </div>
    </React.Fragment>
    )
};

const dataSource = {
    store: {
        type: 'odata',
        key: 'recId',
        url: '/odata/products',
        version: 4
    },
    select: [
        'recId',
        'productName',
        'initPrice',
        'price'
    ]
};




