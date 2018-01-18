FROM zmq
RUN mkdir /zmq
COPY ./newbroker_hb.js /zmq/mybroker.js
WORKDIR /zmq
EXPOSE 8059 8060
CMD node mybroker $LOGGER_URL
