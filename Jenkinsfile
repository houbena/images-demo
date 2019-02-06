pipeline {

    agent any

    stages {
        stage('Build') {
            steps {
                sh 'docker image build -t myapp:build-${BUILD_ID} .'
                sh 'docker image build --target testrunner -t myapp:testbuild-${BUILD_ID} .'
            }
        }
        stage('Test') {
            steps {
                sh 'docker container run myapp:testbuild-${BUILD_ID}'
            }
        }
        stage('Deploy') {
            steps {
                sh 'cd /home/centos/ucp-credentials ; eval "$(<env.sh)"'
                sh 'docker service create --replicas 4 nginx'
            }
        }
    }
}
